using System.Threading.Tasks;

namespace Api.Services.Staff {
    public interface IStaffService {        
        Task<Models.Staff> CreateStaffMember(Models.Staff member);
    }
}