using AutoMapper;
using System.Data;
using AccountControl.Data.Entities;
using AccountControll.Dtos.Account;
using AccountControll.Data.Entities;

namespace AccountControl.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AdmUserDto, AdmUsersEntity>().ReverseMap();
            //CreateMap<User, UserEntity>().ReverseMap();
            //CreateMap<UserDto, User>().ReverseMap();
            //CreateMap<User, CreateUserRequestDto>().ReverseMap();
            //CreateMap<RoleDTO, Role>().ReverseMap();
            //CreateMap<Role, RoleEntity>().ReverseMap();
            //CreateMap<Role, CreateRoleRequestDto>().ReverseMap();
            //CreateMap<Models.Company, CreateCompanyRequestDto>().ReverseMap();
            //CreateMap<User, UpdateUserRequestDto>().ReverseMap();
            //CreateMap<PermissionCategoria, CategoryDTO>().ReverseMap();
            //CreateMap<DataBasic_Surgas_RequestDto, DataSurgas_RequestDto>().ReverseMap();
            //CreateMap<ws_fel_respuestaenvio_basic_RequestDto, Nueva_venta_evento_save_RequestDto>().ReverseMap();
            //CreateMap<UserCompany, UserCompanyEntity>().ReverseMap();
            //CreateMap<ihs_marca_equipoEntity, Lista_ihs_marca_equipo_RequestDto>().ReverseMap();
            //CreateMap<Lista_ihs_marca_equipo_RequestDto, ihs_marca_equipoEntity>().ReverseMap();
            //CreateMap<ihs_equiposEntity, Create_ihs_equipos_RequestDto>().ReverseMap();
            //CreateMap<Create_ihs_equipos_RequestDto, ihs_equiposEntity>().ReverseMap();
            //CreateMap<EmpresaAllRequestDto, CompanyEntity>().ReverseMap();
            //CreateMap<CompanyEntity, EmpresaAllRequestDto>().ReverseMap();
        }
    }
}
