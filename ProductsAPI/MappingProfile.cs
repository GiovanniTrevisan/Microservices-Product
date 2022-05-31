using AutoMapper;
using Categories.API.ViewModels;
using Entities;
using Products.API.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductViewModel>();
        CreateMap<ProductViewModel, Product>();
        CreateMap<CategoryViewModel, Category>();
        CreateMap<Category, CategoryViewModel>();
    }
}