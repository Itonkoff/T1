using Api.Contexts;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.CanteenBalanceRepository {
    public class CanteenBalanceRepository:Repository<CanteenBalance>, ICanteenBalanceRepository {
        public CanteenBalanceRepository(DatabaseContext context) : base(context)
        {
        }        

        private DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }
    }
}