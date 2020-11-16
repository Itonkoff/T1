using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using Api.Repositories.Base;
using AutoMapper;

namespace Api.Services.LibraryService {
    public class LibraryService : ILibraryService {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public LibraryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> CreateBook(Book book)
        {
            await _unitOfWork.BookRepository.AddAsync(book);
            await _unitOfWork.CommitAsync();
            return book;
        }

        public async Task<BookHasStudent> BorrowBook(BookHasStudent bookHasStudent)
        {
            await _unitOfWork.BookHasStudentRepository.AddAsync(bookHasStudent);
            await _unitOfWork.CommitAsync();
            return bookHasStudent;
        }

        public async Task<IEnumerable<BookBorrowed>> GetBooksBorrowedByStudentId(Guid studentRef)
        {
            var studentByRefAsync = await _unitOfWork.Students.GetStudentByRefAsync(studentRef);
            var bookHasStudentById =
                await _unitOfWork.BookHasStudentRepository.GetBookHasStudentById(studentByRefAsync.Id);
            List<BookBorrowed> borrowedBooks = new List<BookBorrowed>();
            foreach (var bookHasStudent in bookHasStudentById)
            {
                if (bookHasStudent.BookNavigation != null)
                {
                    var bookByIdAsync = await _unitOfWork.BookRepository.GetBookByIdAsync(bookHasStudent.Book);
                    var bookBorrowed = _mapper.Map<Book, BookBorrowed>(bookByIdAsync);
                    bookBorrowed.BorrowedDate = bookHasStudent.DateBorrowed;
                    bookBorrowed.Returned = bookHasStudent.Returned;
                    if (!bookHasStudent.Returned && !bookHasStudent.Paid)
                    {
                        var daysInPossession =
                            Convert.ToInt32((DateTime.Now - bookHasStudent.DateBorrowed).TotalDays);
                        if (daysInPossession > bookByIdAsync.DaysAllowableNavigation.Value)
                        {
                           bookBorrowed.Fine = daysInPossession *
                                                bookByIdAsync.PenaltyRateNavigation.Value;
                        }
                    }
                    else if (bookHasStudent.Returned && !bookHasStudent.Paid)
                    {
                        var daysInPossession =
                            Convert.ToInt32((bookHasStudent.DateReturned.Value - bookHasStudent.DateBorrowed).TotalDays);
                        if (daysInPossession > bookByIdAsync.DaysAllowableNavigation.Value)
                        {
                            bookBorrowed.Fine = daysInPossession *
                                                bookByIdAsync.PenaltyRateNavigation.Value;
                        }
                    }

                    borrowedBooks.Add(bookBorrowed);
                }
            }

            return borrowedBooks;
        }

        public async Task ReturnBook(int bookId)
        {
            var bookHasStudentByBookId = await _unitOfWork.BookHasStudentRepository.GetBookHasStudentByBookId(bookId);
            bookHasStudentByBookId.Returned = true;
            bookHasStudentByBookId.DateReturned = DateTime.Now;
            await _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<Book>> GetAllBooks()
        {
            return _unitOfWork.BookRepository.GetAllAsync();
        }

        public async Task<Book> GetBookById(int bookId)
        {
            return await _unitOfWork.BookRepository.GetBookByIdAsync(bookId);
        }
    }
}