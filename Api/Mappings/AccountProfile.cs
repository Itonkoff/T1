using Api.Dtos;
using Api.Models;
using AutoMapper;

namespace Api.Mappings {
    public class AccountProfile : Profile {
        public AccountProfile()
        {
            CreateMap<SignUpDto, User>()
                .ForMember(destination => destination.UserName,
                    options => 
                        options.MapFrom(source => source.Email));
        }
    }
}