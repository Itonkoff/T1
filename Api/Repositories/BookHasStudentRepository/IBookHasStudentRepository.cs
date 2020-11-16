using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Repositories.Base.BookHasStudentRepository {
    public interface IBookHasStudentRepository : IRepository<BookHasStudent> {
        Task<IEnumerable<BookHasStudent>> GetBookHasStudentById(int id);
        
        Task<BookHasStudent> GetBookHasStudentByBookId(int id);
    }
}