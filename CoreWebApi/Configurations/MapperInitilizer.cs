using AutoMapper;
using HotelListing22CoreWebApi.Data;
using HotelListing22CoreWebApi.Models;

//<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="8.1.1" />

namespace HotelListing22CoreWebApi.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            //the fields in the left and a direct corolation to the right 
            //  i.e. Country corolates to CountryDTO and ReverseMap means it goes both ways
            // this class is also dependant on nuget automapper
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel,   HotelDTO>().ReverseMap();
            CreateMap<Hotel,   CreateHotelDTO>().ReverseMap();
        }
    }
}
