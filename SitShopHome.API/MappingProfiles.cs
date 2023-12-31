﻿using AutoMapper;
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

            CreateMap<Gender, ReferenceDTO>()
                .ForMember("title", opts => opts.MapFrom(x => x.GenderTitle))
                .ForMember("id", opts => opts.MapFrom(x => x.GenderId));
            CreateMap<GenderForManipulationDTO, Gender>().ReverseMap();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductForManipulationDTO, Product>().ReverseMap();

            CreateMap<Productcategory, ReferenceDTO>()
                .ForMember("title", opts => opts.MapFrom(x => x.CategoryTitle))
                .ForMember("id", opts => opts.MapFrom(x => x.ProductCategoryId));
            CreateMap<ProductCategoryForManipulationDTO, Productcategory>().ReverseMap();

            CreateMap<PurchaseForCreationDTO, Purchase>();
            CreateMap<PurchaseForUpdateDTO, Purchase>();
            CreateMap<Purchase, PurchaseDTO>();
        }
    }
}
