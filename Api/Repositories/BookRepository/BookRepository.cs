using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Contexts;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.BookRepository {
    public class BookRepository : Repository<Book>, IBookRepository {
        public BookRepository(DatabaseContext context) : base(context)
        {
        }
        
        private DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }

        public Task<Book> GetBookByIdAsync(int bookId)
        {
            return DatabaseContext.Book
                .Include(s=>s.DaysAllowableNavigation)
                .Include(s=>s.PenaltyRateNavigation)
                .SingleOrDefaultAsync(a => a.Id == bookId);
        }
    }
}