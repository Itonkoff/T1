using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Contexts;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.BookHasStudentRepository {
    public class BookHasStudentRepository : Repository<BookHasStudent>, IBookHasStudentRepository {
        public BookHasStudentRepository(DatabaseContext context) : base(context)
        {
        }

        private DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }

        public async Task<IEnumerable<BookHasStudent>> GetBookHasStudentById(int id)
        {
            return await DatabaseContext.BookHasStudent
                .Include(b => b.BookNavigation)
                .Include(b => b.StudentNavigation)
                .Where(b => b.Student == id)
                .ToListAsync();
        }

        public async Task<BookHasStudent> GetBookHasStudentByBookId(int id)
        {
            return await DatabaseContext.BookHasStudent
                .SingleOrDefaultAsync(b => b.Book == id);
        }
    }
}