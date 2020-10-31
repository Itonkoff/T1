using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Services.Students {
    public interface IStudentService {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> CreateStudent(Student newStudent);
        Task UpdateStudent(Student studentToBeUpdated, Student student);
        Task DeleteStudent(Student student);
    }
}