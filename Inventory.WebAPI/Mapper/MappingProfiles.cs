using AutoMapper;
using Inventory.DTOs.Category;
using Inventory.DTOs.InventoryMovement;
using Inventory.DTOs.InventoryStock;
using Inventory.DTOs.MovementType;
using Inventory.DTOs.Product;
using Inventory.DTOs.Supplier;
using Inventory.Entities;

namespace Inventory.WebAPI.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            MapCategory();
            MapInventoryMovement();
            MapInventoryStock();
            MapMovementType();
            MapProduct();
            MapSupplier();
        }

        private void MapCategory()
        {
            CreateMap<CategoryToCreateDTO, Category>();
            CreateMap<CategoryToEditDTO, Category>();
            CreateMap<Category, CategoryToListDTO>();
        }

        private void MapInventoryMovement()
        {
            CreateMap<InventoryMovementToCreateDTO, InventoryMovement>();
            CreateMap<InventoryMovementToEditDTO, InventoryMovement>();
            CreateMap<InventoryMovement, InventoryMovementToListDTO>()
                .ForMember(
                    dest => dest.MovementTypeName,
                    opt => opt.MapFrom(src => src.MovementType.Name))
                .ForMember(
                    dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product.Name));
        }

        private void MapInventoryStock()
        {
            CreateMap<InventoryStockToCreateDTO, InventoryStock>();
            CreateMap<InventoryStockToEditDTO, InventoryStock>();
            CreateMap<InventoryStock, InventoryStockToListDTO>()
                .ForMember(
                    dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product.Name));
        }

        private void MapMovementType()
        {
            CreateMap<MovementTypeToCreateDTO, MovementType>();
            CreateMap<MovementTypeToEditDTO, MovementType>();
            CreateMap<MovementType, MovementTypeToListDTO>();
        }

        private void MapProduct()
        {
            CreateMap<ProductToCreateDTO, Product>();
            CreateMap<ProductToEditDTO, Product>();
            CreateMap<Product, ProductToListDTO>()
                .ForMember(
                    dest => dest.SupplierName,
                    opt => opt.MapFrom(src => src.Supplier.Name))
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name));
        }

        private void MapSupplier()
        {
            CreateMap<SupplierToCreateDTO, Supplier>();
            CreateMap<SupplierToEditDTO, Supplier>();
            CreateMap<Supplier, SupplierToListDTO>();
        }
    }
}