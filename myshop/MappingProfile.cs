using AutoMapper;
using MyShop.Core.Common.Models.Products;
using MyShop.Core.Entities;
using MyShop.Web.Models;

namespace MyShop.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base()
        {
            CreateMap<RegisterCustomerVM, ApplicationUser>();
            CreateMap<Discount, DiscountDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category == null ? null : src.Category.Name));
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateOrUpdateProductRequest, Product>()
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => (
                    src.DiscountQuantity == 0 || src.DiscountQuantity == 0
                    ? null
                    : new Discount
                    {
                        Quantity = src.DiscountQuantity,
                        Percentage = src.DiscountPercentage / 100,
                    }
                )));
        }
    }
}
