using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Repositories.Base.BookRepository {
    public interface IBookRepository:IRepository<Book> {
        Task<Book> GetBookByIdAsync(int studentId);
    }
}