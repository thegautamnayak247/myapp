﻿using AutoMapper;
using MyApplication.api.Models;
using System.Collections.Generic;
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