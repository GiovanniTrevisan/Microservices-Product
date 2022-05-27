using AutoMapper;
using Categories.API.ViewModels;
using Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryViewModel>();
        CreateMap<CategoryViewModel, Category>();
    }
}