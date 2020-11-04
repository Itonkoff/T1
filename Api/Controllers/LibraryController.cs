using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    public class LibraryController : Controller {
        [HttpPost("Home")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}