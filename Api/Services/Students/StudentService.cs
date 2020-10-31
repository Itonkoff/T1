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

        public async Task<Student> CreateStudent(Student newStudent)
        {
            newStudent.Registered = false;
            newStudent.RegNumber = Guid.NewGuid();
            await _unitOfWork.Students.AddAsync(newStudent);
            await _unitOfWork.CommitAsync();
            return newStudent;
        }

        public async Task UpdateStudent(Student studentToBeUpdated, Student student)
        {
            //TODO: to handle changing of program and academic level
            studentToBeUpdated.FirstName = student.FirstName;
            studentToBeUpdated.LastName = student.LastName;
            studentToBeUpdated.NationalId = student.NationalId;
            studentToBeUpdated.PhysicalAddress = student.PhysicalAddress;

            if (!studentToBeUpdated.Registered && student.Registered)
                studentToBeUpdated.Registered = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteStudent(Student student)
        {
            _unitOfWork.Students.Remove(student);
            await _unitOfWork.CommitAsync();
        }
    }
}