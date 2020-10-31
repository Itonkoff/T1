using Api.Dtos;
using Api.Models;
using AutoMapper;

namespace Api.Mappings {
    public class StudentProfile : Profile {
        public StudentProfile()
        {
            //Resource to Domain
            CreateMap<StudentRegistrationResourceDto, Student>();
            CreateMap<EditStudentResourceDto, Student>();
            
            //Domain to Resource
            CreateMap<Student, EditedStudentResourceDto>();
            CreateMap<Student, StudentDetailResourceDto>();
        }
    }
}