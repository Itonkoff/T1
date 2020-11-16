using Api.Dtos;
using Api.Models;
using AutoMapper;

namespace Api.Mappings {
    public class CanteenProfiles : Profile {
        public CanteenProfiles()
        {
            //Resource to domain
            CreateMap<MealResourceDto, CanteenPriceList>()
                .ForMember(dest => dest.Price,
                    options =>
                        options.MapFrom(source => source.Price.ToString()));

            CreateMap<ChangeMealPriceResourceDto, CanteenPriceList>()
                .ForMember(dest => dest.Price,
                    options =>
                        options.MapFrom(source => source.Price.ToString()));

            CreateMap<BillStudentResourceDto, CanteenBalance>()
                .ForMember(dest => dest.Cr,
                    options =>
                        options.MapFrom(source => source.Amount));
        }
    }
}