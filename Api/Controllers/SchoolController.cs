using System.Threading.Tasks;
using Api.Dtos;
using Api.Services.SchoolService;
using Api.Services.Students;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : Controller {
        private ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet("Level/Program")]
        public async Task<IActionResult> GetLevelsAndPrograms()
        {
            return Ok(await _schoolService.GetLevelsAndPrograms());
        }

        [HttpGet("Modules/{level}/{program}")]
        public async Task<IActionResult> GetModulesPerProgramLevel(int level, int program)
        {
            var programLevelDto = new ProgramLevelDto
            {
                Level = level,
                Program = program
            };
            var modulesPerProgramLevel = 
                await _schoolService.GetModulesPerProgramLevel(programLevelDto);
            return Ok(modulesPerProgramLevel);
        }

        [HttpPost("Attend")]
        public async Task<IActionResult> RecordAttendance([FromBody] AttendanceDto attendanceDto)
        {
            var addAttendie = await _schoolService.AddAttendie(attendanceDto);
            return NotFound(addAttendie);
        }
    }
}