﻿using ApiGotadevida.DTOS;
using ApiGotadevida.Entitys;
using AutoMapper;

namespace ApiGotadevida.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<UserDTO, Users>().ReverseMap();
            CreateMap<Users, UserCreateDTO>().ReverseMap();
            CreateMap<UserListProfileDTO, UserProfile>().ReverseMap();
        }
    }
}
