using System.Threading.Tasks;
using Api.Repositories.Base;

namespace Api.Services.Staff {
    public class StaffService:IStaffService {
        private IUnitOfWork _unitOfWork;

        public StaffService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Models.Staff> CreateStaffMember(Models.Staff member)
        {
            await _unitOfWork.StaffMembers.AddAsync(member);
            await _unitOfWork.CommitAsync();
            return member;
        }
    }
}