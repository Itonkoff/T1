using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using Api.Repositories.Base;

namespace Api.Services.Students {
    public class StudentService : IStudentService {
        private IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
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
    }
}