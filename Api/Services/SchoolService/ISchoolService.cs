using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Models;

namespace Api.Services.SchoolService {
    public interface ISchoolService {
        Task<LevelsAndPrograms> GetLevelsAndPrograms();
        Task<IEnumerable<ModuleSummary>> GetModulesPerProgramLevel(ProgramLevelDto programLevelDto);
        Task<AttendanceDto> AddAttendie(AttendanceDto attendanceDto);
    }
}