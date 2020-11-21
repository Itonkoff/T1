using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Api.Contexts;
using Api.Dtos;
using Api.Models;
using Api.Services.Students;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers {
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller {
        private IStudentService _studentService;
        private IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        // GET: Students
        [HttpGet("")]
        public async Task<IActionResult> Students()
        {
            var studentsFromDB = await _studentService.GetAllStudents();
            var students =
                _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDetailResourceDto>>(studentsFromDB);
            return Ok(students);
        }

        // GET: Students/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentfromDb = await _studentService.GetStudentById(id.Value);
            if (studentfromDb == null)
            {
                return NotFound();
            }

            var student = _mapper.Map<Student, StudentDetailResourceDto>(studentfromDb);

            return Ok(student);
        }
        
        
        [HttpGet("Dash/{studentId}")]
        public async Task<IActionResult> GetStudentDashboardDetails(int studentId)
        {
            return Ok(await _studentService.GetStudentDashBoardInfo(studentId));
        }

        private async Task<bool> StudentExists(int id)
        {
            var studentById = await _studentService.GetStudentById(id);
            return studentById != null;
        }
    }
}