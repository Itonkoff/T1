using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Models;
using Api.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers {
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller {
        
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationController(
            IMapper mapper, 
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptionsSnapshot<JwtSettings> jwtSettings
            )
        {
            _jwtSettings = jwtSettings.Value;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto userSignUpDto)
        {
            var user = _mapper.Map<SignUpDto, User>(userSignUpDto);

            var userCreateResult = await _userManager.CreateAsync(user, userSignUpDto.Password);

            if (userCreateResult.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }

            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }
        
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(LoginDto userLoginResource)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userLoginResource.Email);
            if (user is null)
            {
                return NotFound("User not found");
            }

            var userSigninResult = await _userManager.CheckPasswordAsync(user, userLoginResource.Password);

            if (userSigninResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                string token = GenerateJwt(user, roles);
                return Ok(token);
            }

            return BadRequest("Email or password incorrect.");
        }
        
        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if(string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Role name should be provided.");
            }

            var newRole = new Role
            {
                Name = roleName
            };

            var roleResult = await _roleManager.CreateAsync(newRole);

            if (roleResult.Succeeded)
            {
                return Ok();
            }

            return Problem(roleResult.Errors.First().Description, null, 500);
        }
        
        [Authorize]
        [HttpPost("User/Role")]
        public async Task<IActionResult> AddUserToRole(string userEmail, string roleName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userEmail);

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return Ok();
            }

            return Problem(result.Errors.First().Description, null, 500);
        }
        
        private string GenerateJwt(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Issuer));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires : expires,
                signingCredentials : creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}