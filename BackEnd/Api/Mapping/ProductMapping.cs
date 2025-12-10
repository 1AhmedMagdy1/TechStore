using AutoMapper;
using Core.DTOS;
using Core.Models;

namespace Api.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            // CreateMap<Source, Destination>();
            
            CreateMap<Product,ProductDto>
                ().ForMember(x => x.CategoryName,
                op => op.MapFrom(src => src.Category.CategoryName))
                
                .ReverseMap();

            CreateMap<ProductsPhoto, ProductPhotoDto>().ReverseMap();
        }
    }
}
