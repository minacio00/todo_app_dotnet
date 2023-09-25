using AutoMapper;
using TodoApp.Data.dtos;
using TodoApp.Models;

namespace TodoApp.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, ReadCategoryDto>();
        }
    }
}