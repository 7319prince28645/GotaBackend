using ApiGotadevida.DTOS;
using ApiGotadevida.DTOS.Post;
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
            CreateMap<Users, PostUser>().ReverseMap();
            CreateMap<PostUser, PostMsjDTO>().ReverseMap();
            CreateMap<PostUser, ListPosts>().ReverseMap();
        }
    }
}
