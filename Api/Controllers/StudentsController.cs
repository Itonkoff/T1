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

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] StudentRegistrationResourceDto newStudent)
        {
            var studentToBeCreated = _mapper.Map<StudentRegistrationResourceDto, Student>(newStudent);
            var createdStudent = await _studentService.CreateStudent(studentToBeCreated);
            var student = _mapper.Map<Student, StudentDetailResourceDto>(createdStudent);
            return Ok(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditStudentResourceDto studentToBeUpdated)
        {
            var student = _mapper.Map<EditStudentResourceDto, Student>(studentToBeUpdated);
            if (id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var studentById = await _studentService.GetStudentById(id);
                    if (studentById != null)
                    {
                        await _studentService.UpdateStudent(studentById, student);
                    }
                }
                catch (Exception)
                {
                    var exists = await StudentExists(student.Id);
                    if (!exists)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            var editedStudent = _mapper.Map<Student, EditedStudentResourceDto>(student);
            editedStudent.Id = id;
            return Ok(editedStudent);
        }

        // // POST: Students/Delete/5
        // [HttpPost("Delete/{id}")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var student = await _studentService.GetStudentById(id);
        //     if (student != null)
        //     {
        //         await _studentService.DeleteStudent(student);
        //         return Ok();
        //     }
        //     else
        //     {
        //         return NotFound();
        //     }
        // }
        
        // POST: Students/Register/5
        [HttpPost("Register/{id}")]
        public async Task<IActionResult> RegisterStudent(int id)
        {
            var studentById = await _studentService.GetStudentById(id);
            var studentToUpDate = await _studentService.GetStudentById(id);

            if (studentById != null && studentToUpDate != null)
            {
                if (!studentToUpDate.Registered)
                {
                    studentToUpDate.Registered = true;
                    await _studentService.UpdateStudent(studentById, studentToUpDate);
                    return Ok("Registered");
                }
            }
            return NotFound();
        }

        private async Task<bool> StudentExists(int id)
        {
            var studentById = await _studentService.GetStudentById(id);
            return studentById != null;
        }
    }
}