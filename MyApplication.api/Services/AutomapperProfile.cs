using AutoMapper;
using MyApplication.api.Models;
using DTO = MyApplication.Core;
namespace MyApplication.api.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, DTO.User>().ReverseMap();
        }
    }
}