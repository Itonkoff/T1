using Api.Models;
using AutoMapper;

namespace Api.Mappings {
    public class SchoolProfiles : Profile {
        public SchoolProfiles()
        {
            CreateMap<StudentProgram, ProgramSummary>();
            CreateMap<Module, ModuleSummary>();
        }
    }
}