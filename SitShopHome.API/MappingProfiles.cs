using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace SitShopHome.API
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember("CustomerFullName", opts => opts.MapFrom(x => string.Join(' ',x.CustomerName, x.CustomerSurname)));
            CreateMap<CustomerForManipulationDTO, Customer>().ReverseMap();
        }
    }
}
