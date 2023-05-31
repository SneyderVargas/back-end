using AutoMapper;
using login.Data.Entities;
using login.Dtos.Security;
using login.Infrastructure.Models;
using System.Data;

namespace login.Domain.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            //CreateMap<User, UserEntity>().ReverseMap();
            //CreateMap<UserDto, User>().ReverseMap();
            //CreateMap<User, CreateUserRequestDto>().ReverseMap();
            //CreateMap<RoleDTO, Role>().ReverseMap();
            //CreateMap<Role, RoleEntity>().ReverseMap();
            //CreateMap<Role, CreateRoleRequestDto>().ReverseMap();
            //CreateMap<Models.Company, CreateCompanyRequestDto>().ReverseMap();
            //CreateMap<User, UpdateUserRequestDto>().ReverseMap();
        }
    }
}
