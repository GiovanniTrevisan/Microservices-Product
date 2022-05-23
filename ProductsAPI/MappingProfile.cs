using AutoMapper;
using Entities;
using Products.API.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductViewModel>();
        CreateMap<ProductViewModel, Product>();
    }
}