using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Models;
using Api.Services.Staff;
using Api.Services.Students;
using Api.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;
        private readonly JwtSettings _jwtSettings;
        private IStudentService _studentService;
        private IStaffService _staffService;

        public AuthenticationController(
            IMapper mapper,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptionsSnapshot<JwtSettings> jwtSettings,
            IStudentService studentService,
            IStaffService staffService
        )
        {
            _staffService = staffService;
            _studentService = studentService;
            _jwtSettings = jwtSettings.Value;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("SignUp/Student")]
        public async Task<IActionResult> StudentSignUp(StudentSignUpResourceDto userStudentSignUpResourceDto)
        {
            var student = await _studentService.GetStudentByRefAsync(userStudentSignUpResourceDto.StudentId);
            if (student != null)
            {
                var user = _mapper.Map<StudentSignUpResourceDto, User>(userStudentSignUpResourceDto);

                var userCreateResult = await _userManager.CreateAsync(user, userStudentSignUpResourceDto.Password);

                if (userCreateResult.Succeeded)
                {
                    var result = await _userManager.AddToRoleAsync(user, "student");
                    var createdUser =
                        _userManager.Users.SingleOrDefault(u => u.UserName == userStudentSignUpResourceDto.Email);
                    var updateStudentUserId = await _studentService.UpdateStudentUserId(student, createdUser.Id);
                    if (result.Succeeded && updateStudentUserId > 0)
                    {
                        return Created(string.Empty, string.Empty);
                    }
                }

                return Problem(userCreateResult.Errors.First().Description, null, 500);
            }

            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("SignUp/Librarian")]
        public async Task<IActionResult> LibrarianSignUp(StaffSignUpResourceDto userStaffSignUpResourceDto)
        {
            var user = _mapper.Map<StaffSignUpResourceDto, User>(userStaffSignUpResourceDto);

            var userCreateResult = await _userManager.CreateAsync(user, userStaffSignUpResourceDto.Password);

            if (userCreateResult.Succeeded)
            {
                var result = await _userManager.AddToRoleAsync(user, "librarian");
                if (result.Succeeded)
                {
                    var createdUser =
                        _userManager.Users.SingleOrDefault(u => u.UserName == userStaffSignUpResourceDto.Email);
                    var staff = _mapper.Map<StaffSignUpResourceDto, Staff>(userStaffSignUpResourceDto);
                    staff.UserId = createdUser.Id;
                    await _staffService.CreateStaffMember(staff);
                    return Created(string.Empty, string.Empty);
                }
            }

            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        [AllowAnonymous]
        [HttpPost("SignUp/Canteen-Help")]
        public async Task<IActionResult> CanteenHelpSignUp(StaffSignUpResourceDto userStaffSignUpResourceDto)
        {
            var user = _mapper.Map<StaffSignUpResourceDto, User>(userStaffSignUpResourceDto);

            var userCreateResult = await _userManager.CreateAsync(user, userStaffSignUpResourceDto.Password);

            if (userCreateResult.Succeeded)
            {
                var result = await _userManager.AddToRoleAsync(user, "canteen_help");
                if (result.Succeeded)
                {
                    var createdUser =
                        _userManager.Users.SingleOrDefault(u => u.UserName == userStaffSignUpResourceDto.Email);
                    var staff = _mapper.Map<StaffSignUpResourceDto, Staff>(userStaffSignUpResourceDto);
                    staff.UserId = createdUser.Id;
                    await _staffService.CreateStaffMember(staff);
                    return Created(string.Empty, string.Empty);
                }
            }

            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        [AllowAnonymous]
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
                var role = roles.Where(r => r.Equals("student")).SingleOrDefault();
                Student student = null;
                if (!string.IsNullOrEmpty(role))
                {
                    student = await _studentService.GetStudentByUserIdAsync(user.Id);
                }

                var tokenResourceDto = new TokenResourceDto
                {
                    Token = GenerateJwt(user, roles)
                };
                if (student != null)
                {
                    tokenResourceDto.Student = student.Id;
                }

                return Ok(tokenResourceDto);
            }

            return BadRequest("Email or password incorrect.");
        }

        [Authorize(Roles = "Sis_admin")]
        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
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

        [Authorize(Roles = "Sis_admin")]
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
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
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
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}