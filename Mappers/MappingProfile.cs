using AutoMapper;
using road_to_asp.Dtos;
using road_to_asp.Models;

namespace road_to_asp.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();

        }
    }
}
