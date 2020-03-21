using AutoMapper;
using UniversityApp.DataTransferObjects;
using UniversityApp.Models;

namespace UniversityApp.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressViewModel>()
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Id));

            CreateMap<AddressViewModel, Address>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AddressId));
              
        }
    }
}
