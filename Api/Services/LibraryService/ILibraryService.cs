using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Services.LibraryService {
    public interface ILibraryService {
        Task<Book> CreateBook(Book book);
        Task<BookHasStudent> BorrowBook(BookHasStudent bookHasStudent);
        Task<IEnumerable<BookBorrowed>> GetBooksBorrowedByStudentId(Guid studentRef);
        Task ReturnBook(int bookId);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int bookId);
    }
}