using Api.Dtos;
using Api.Models;
using AutoMapper;

namespace Api.Mappings {
    public class AccountProfile : Profile {
        public AccountProfile()
        {
            //Resource to Domain
            CreateMap<StudentSignUpResourceDto, User>()
                .ForMember(destination => destination.UserName,
                    options => 
                        options.MapFrom(source => source.Email));
            CreateMap<StaffSignUpResourceDto,User>()
                .ForMember(destination => destination.UserName,
                    options => 
                        options.MapFrom(source => source.Email));
            CreateMap<StaffSignUpResourceDto, Staff>();
        }
    }
}