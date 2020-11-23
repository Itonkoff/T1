using System.Threading.Tasks;

namespace Api.Repositories.Base.Module {
    public interface IModuleRepository : IRepository<Models.Module> {
        Task<Models.Module> GetFullModule(int module);
    }
}