using System.Linq;
using System.Threading.Tasks;
using Api.Contexts;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.CanteenPricelistRepository {
    public class CanteenPriceListListRepository : Repository<CanteenPriceList>, ICanteenPriceListRepository {
        public CanteenPriceListListRepository(DatabaseContext context) : base(context)
        {
        }

        private DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }
    }
}