using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Services.Students {
    public interface IStudentService {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);        
        Task<int> UpdateStudentUserId(Student studentToBeUpdated, Guid UserId);
    }
}