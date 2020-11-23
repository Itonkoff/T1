using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Models;
using Api.Repositories.Base;
using Api.Services.CanteenService;
using Api.Services.LibraryService;

namespace Api.Services.Students {
    public class StudentService : IStudentService {
        private IUnitOfWork _unitOfWork;
        private ILibraryService _libraryService;
        private ICanteenService _canteenService;

        public StudentService(
            IUnitOfWork unitOfWork,
            ILibraryService libraryService,
            ICanteenService canteenService
        )
        {
            _canteenService = canteenService;
            _libraryService = libraryService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _unitOfWork.Students.GetAllAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _unitOfWork.Students.GetByIdAsync(id);
        }

        public async Task<int> UpdateStudentUserId(Student studentToBeUpdated, Guid userId)
        {
            studentToBeUpdated.UserId = userId;
            return await _unitOfWork.CommitAsync();
        }

        public async Task<Student> GetStudentByRefAsync(Guid borrowBookStudent)
        {
            return await _unitOfWork.Students.GetStudentByRefAsync(borrowBookStudent);
        }

        public async Task<StudentDashBoardInfoDto> GetStudentDashBoardInfo(int studentId)
        {
            var studentDashBoard = new StudentDashBoardInfoDto();
            var student = await _unitOfWork.Students.GetByIdAsync(studentId);
            var bookHasStudents =
                await _libraryService.GetBooksBorrowedByStudentId(student.RegNumber);

            var booksAsList = bookHasStudents.ToList();
            studentDashBoard.NumberOfBooksBorrowed = booksAsList.Count;
            foreach (var bookBorrowed in booksAsList)
            {
                studentDashBoard.Penalty += bookBorrowed.Fine;
            }

            studentDashBoard.CanteenBalance =
                await _canteenService.CalculateBalance(_canteenService.CanteenBalances(student));

            return studentDashBoard;
        }

        public async Task<Student> GetStudentByUserIdAsync(Guid userId)
        {
            return await _unitOfWork.Students.GetStudentByUserAsync(userId);
        }

    }
}