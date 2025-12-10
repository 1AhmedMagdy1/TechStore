using AutoMapper;
using Core.DTOS;
using Core.Models;

namespace Api.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, CreateUserDTO>()
                .ForMember(x=>x.Email,d=>d.MapFrom(d=>d.Email))
                .ForMember(x => x.UserName, d => d.MapFrom(d => d.UserName))
                .ReverseMap();
        }
    }
}
