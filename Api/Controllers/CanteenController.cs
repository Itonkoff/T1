using System.Threading.Tasks;
using Api.Dtos;
using Api.Models;
using Api.Repositories.StudentRepository;
using Api.Services.CanteenService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    public class CanteenController : Controller {
        private ICanteenService _canteenService;
        private IMapper _mapper;


        public CanteenController(ICanteenService canteenService, IMapper mapper)
        {
            _mapper = mapper;
            _canteenService = canteenService;
        }

        [HttpGet("Meals")]
        public async Task<IActionResult> Meals()
        {
            return Ok(await _canteenService.GetAllPricesAsync());
        }

        [HttpPost("Meal")]
        public async Task<IActionResult> Meal([FromBody] MealResourceDto newMeal)
        {
            var meal = _mapper.Map<MealResourceDto, CanteenPriceList>(newMeal);
            var createdMeal = await _canteenService.CreatePriceListItemAsync(meal);
            return Ok(createdMeal);
        }

        [HttpPost("Meal/Price")]
        public async Task<IActionResult> ChangeMealPrice([FromBody] ChangeMealPriceResourceDto newPrice)
        {
            var canteenPriceList = _mapper.Map<ChangeMealPriceResourceDto, CanteenPriceList>(newPrice);
            return Ok(await _canteenService.UpdatePriceAsync(canteenPriceList));
        }

        [HttpPost("Bill")]
        public async Task<IActionResult> BillStudent([FromBody] BillStudentResourceDto bill)
        {
            var billStudentResourceDto = await _canteenService.BillStudent(bill);
            if (billStudentResourceDto != null)
                return Ok();
            return BadRequest("Insufficient funds");
        }
    }
}