using AutoMapper;
using Inventory.DTOs.Category;
using Inventory.Entities;

namespace Inventory.WebAPI.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CategoryToCreateDTO, Category>();
            CreateMap<CategoryToEditDTO, Category>();
            CreateMap<Category, CategoryToListDTO>();
        }
    }
}