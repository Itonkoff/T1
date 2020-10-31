using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using Api.Repositories.Base;

namespace Api.Repositories.StudentRepository {
    public interface IStudentRepository:IRepository<Student> { }
}