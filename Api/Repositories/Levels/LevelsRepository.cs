using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.Levels {
    public class LevelsRepository :Repository<AcademicLevel>,ILevelsRepository{
        public LevelsRepository(DbContext context) : base(context)
        {
        }
    }
}