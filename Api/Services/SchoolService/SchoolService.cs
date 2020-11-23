using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Models;
using Api.Repositories.Base;
using Api.Services.Students;
using AutoMapper;

namespace Api.Services.SchoolService {
    public class SchoolService : ISchoolService {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IStudentService _studentService;

        public SchoolService(IUnitOfWork unitOfWork, IMapper mapper, IStudentService studentService)
        {
            _studentService = studentService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<LevelsAndPrograms> GetLevelsAndPrograms()
        {
            var levelsAndPrograms = new LevelsAndPrograms();
            levelsAndPrograms.Levels = new List<double>();

            var allLevelsAsync = await _unitOfWork.LevelsRepository.GetAllAsync();
            var studentPrograms = await _unitOfWork.ProgramRepository.GetAllAsync();

            foreach (var level in allLevelsAsync)
            {
                levelsAndPrograms.Levels.Add(level.Value);
            }

            levelsAndPrograms.ProgramSummaries =
                _mapper.Map<IEnumerable<StudentProgram>, IEnumerable<ProgramSummary>>(studentPrograms).ToList();
            return levelsAndPrograms;
        }

        public async Task<IEnumerable<ModuleSummary>> GetModulesPerProgramLevel(ProgramLevelDto programLevelDto)
        {
            var moduleHasAcademicLevels = _unitOfWork.ModuleHasAcademicLevelRepository
                .Find(m => m.AcademicLevel == programLevelDto.Level).ToList();
            List<Module> modules = new List<Module>();
            foreach (var moduleHasAcademicLevel in moduleHasAcademicLevels)
            {
                var module =
                    await _unitOfWork.ModuleRepository.GetFullModule(moduleHasAcademicLevel.Module);
                var moduleHasProgram =
                    module.ModuleHasProgram
                        .SingleOrDefault(m => m.Program == programLevelDto.Program);

                // var byIdAsync = 
                //     _unitOfWork.ModuleHasProgramRepository

                var r = 0;
                // var moduleHasProgram = moduleHasPrograms
                //     .SingleOrDefault(m => m.Program == programLevelDto.Program && m.Module == module.Id);
                //
                if (moduleHasProgram != null)
                {
                    modules.Add(module);
                }
            }

            var modulesPerProgramLevel =
                _mapper.Map<IEnumerable<Module>, IEnumerable<ModuleSummary>>(modules);
            return modulesPerProgramLevel;
        }

        public async Task<AttendanceDto> AddAttendie(AttendanceDto attendanceDto)
        {
            var studentByRefAsync = await _studentService.GetStudentByRefAsync(attendanceDto.Student);
            var moduleHasAcademicLevelHasWeekDays = _unitOfWork.ModuleHasWeekRepository
                .Find(m =>
                    m.Module == attendanceDto.Module
                    && m.AcademicLevel == studentByRefAsync.AcademicLevel)
                .SingleOrDefault();
            var studentHasModuleHasAcademicLevelHasWeekDay = new StudentHasModuleHasAcademicLevelHasWeekDay
            {
                AcademicLevel = moduleHasAcademicLevelHasWeekDays.AcademicLevel,
                Date = DateTime.Now,
                Module = moduleHasAcademicLevelHasWeekDays.Module,
                ModuleHasAcademicLevelHasWeekDay = moduleHasAcademicLevelHasWeekDays,
                Student = studentByRefAsync.Id
            };
            await _unitOfWork.StudentHasModuleRepository.AddAsync(studentHasModuleHasAcademicLevelHasWeekDay);
            await _unitOfWork.CommitAsync();
            return attendanceDto;
        }
    }
}