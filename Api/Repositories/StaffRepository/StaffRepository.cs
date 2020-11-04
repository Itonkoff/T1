using System.Threading.Tasks;
using Api.Contexts;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.StaffRepository {
    public class StaffRepository : Repository<Staff>, IStaffRepository {
        public StaffRepository(DatabaseContext context)
            : base(context)
        {
        }
        
        private DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }
    }
}

