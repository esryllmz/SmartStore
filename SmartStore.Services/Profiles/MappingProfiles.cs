using AutoMapper;
using SmartStore.Models.Dtos.Categories.Requests;
using SmartStore.Models.Dtos.Categories.Responses;
using SmartStore.Models.Dtos.Products.Requests;
using SmartStore.Models.Dtos.Products.Responses;
using SmartStore.Models.Entities;

namespace SmartStore.Services.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<Category, CategoryResponseDto>();

            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, CreatedProductResponseDto>();
            CreateMap<Product, ProductResponseDto>()
              .ForMember(prd => prd.Category, opt => opt.MapFrom(p => p.Category.Name)).ReverseMap()
              .ForMember(prd => prd.Category, opt => opt.Ignore());
        }


    }
}
