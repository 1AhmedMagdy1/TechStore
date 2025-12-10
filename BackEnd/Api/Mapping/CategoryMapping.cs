using AutoMapper;
using Core.DTOS;
using Core.Models;

namespace Api.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Categoty,CategoryDTO>().ReverseMap();
        }
    }
}
