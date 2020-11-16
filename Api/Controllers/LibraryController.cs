using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Models;
using Api.Repositories.StudentRepository;
using Api.Services.LibraryService;
using Api.Services.Students;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    public class LibraryController : Controller {
        private IMapper _mapper;
        private ILibraryService _libraryService;
        private IStudentService _studentService;

        public LibraryController(IMapper mapper, ILibraryService libraryService,IStudentService studentService)
        {
            _studentService = studentService;
            _libraryService = libraryService;
            _mapper = mapper;
        }

        [HttpGet("Book/All")]
        public async Task<IActionResult> GetAllBooks()
        {
            var allBooks = await _libraryService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("Book/{bookID}")]
        public async Task<IActionResult> GetBookById(int bookID)
        {            
            return Ok(_mapper.Map<Book,BookResourceDto>(await _libraryService.GetBookById(bookID)));
        }

        [HttpGet("Book/Borrowed/ByStudentRef")]
        public async Task<IActionResult> GetBooksBorrowedByStudent(Guid studentRef)
        {
            var booksBorrowedByStudentId = await _libraryService.GetBooksBorrowedByStudentId(studentRef);
            return Ok(booksBorrowedByStudentId);
        }

        [HttpPost("Book/Add")]
        public async Task<IActionResult> AddBook([FromBody] NewBookResourceDto newBook)
        {
            var book = _mapper.Map<NewBookResourceDto, Book>(newBook);
            await _libraryService.CreateBook(book);
            return Ok(newBook);
        }

        [HttpPost("Book/Borrow")]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowBookResourceDto borrowBook)
        {
            var bookHasStudent = _mapper.Map<BorrowBookResourceDto, BookHasStudent>(borrowBook);
            bookHasStudent.DateBorrowed = DateTime.Now;
            var studentByRefAsync = await _studentService.GetStudentByRefAsync(borrowBook.StudentId);
            bookHasStudent.Student = studentByRefAsync.Id;
            await _libraryService.BorrowBook(bookHasStudent);
            return Ok(borrowBook);
        }

        [HttpPost("Book/Return")]
        public async Task<IActionResult> ReturnBook(int bookId)
        {
            await _libraryService.ReturnBook(bookId);
            return Ok();
        }
    }
}