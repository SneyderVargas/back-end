using AutoMapper;
using login.Data;
using login.Data.Entities;
using login.Infrastructure.Models;
using login.Resx;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace login.Infrastructure.Services.Security
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly DbDefaultContext _dbDefaultContext;

        public AccountService(IMapper mapper, IConfiguration configuration, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, DbDefaultContext dbDefaultContext)
        {
            _mapper = mapper;
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
            _dbDefaultContext = dbDefaultContext;
        }

        public async Task<(bool Success, string Message, User User, List<PermissionCodes> Permissions, int AdId)> Login(string UserName, string Password, CancellationToken ct)
        {
            User user = new User();
            List<PermissionEntity> permits = new List<PermissionEntity>();
            List<PermissionCodes> perm = new List<PermissionCodes>();
            try 
            {
                //Buscar el usuario por nombre de usuario
                var userEntity = await _userManager.FindByNameAsync(UserName);
                if (userEntity == null)
                    return (false, SecurityMsg.UserPasswordInvalid, null, null, -1);
                // Validar la contraseña
                var isPwdValid = await _userManager.CheckPasswordAsync(userEntity, Password);
                if (!isPwdValid)
                    return (false, SecurityMsg.UserPasswordInvalid, null, null, -1);
                // Validar que el usuario se encuentre activo
                if (!userEntity.Active)
                    return (false, SecurityMsg.UserInactive, null, null, -1);
                // Validar si el tiempo de la sesión no ha vencido
                var isLogInTimeout = true;
                if (userEntity.LogInTimeout.CompareTo(DateTime.MinValue) == 0)
                    isLogInTimeout = false;
                else if (userEntity.LogInTimeout.CompareTo(DateTime.Now) > 0)
                    isLogInTimeout = false;
                // Validar que el usuario no se encuentre logueado en otra sesión
                if (userEntity.IsLoggedIn && !isLogInTimeout)
                    return (false, SecurityMsg.UserLoggedIn, null, null, -1);
                // Validar que el usuario pueda realizar login
                if (!await _signInManager.CanSignInAsync(userEntity))
                    return (false, SecurityMsg.UserPasswordInvalid, null, null, -1);
                // Reiniciar el conteo de bloqueos
                if (_userManager.SupportsUserLockout)
                    await _userManager.ResetAccessFailedCountAsync(userEntity);
                // Inicar sesión del usuario
                var expires = Convert.ToInt32(_configuration["LogInTimeoutMinutes"]);
                userEntity.IsLoggedIn = true;
                userEntity.LogInTimeout = DateTime.Now.AddMinutes(expires);
                await _userManager.UpdateAsync(userEntity);

                // Obtener usuario
                user = await GetUserAsync(userEntity);

                //Obtener permisos de usuario y su rol
                foreach (var us in user.Roles)
                {


                    var roleQuery = from st in _dbDefaultContext.Roles
                                    where st.NormalizedName == us.ToString()
                                    select st;
                    var role = roleQuery.FirstOrDefault();
                    var query = "select p.Id, p.Code, p.Name, p.Description, p.PermissioncategoryId, p.Fk_form from aspnetpermission p join aspnetpermissionrol pr on pr.PermissionId = p.Id where pr.RolId = '" + role.Id + "'";
                    var userPermits = from st in _dbDefaultContext.permissionUserEntities
                                      where st.UserId == user.Id
                                      select st;
                    if (userPermits.FirstOrDefault() != null)
                    {
                        query = "select * from (" +
                            "(select p.Id, p.Code, p.Name, p.Description, p.PermissioncategoryId, p.Fk_form " +
                            "from aspnetpermission p " +
                            "join aspnetpermissionrol pr on pr.PermissionId = p.Id " +
                            "where pr.RolId = '" + role.Id + "') " +
                            "union distinct " +
                            "(select p.Id, p.Code, p.Name, p.Description, p.PermissioncategoryId, p.Fk_form " +
                            "from aspnetpermission p " +
                            "join aspnetpermissionuser pu on pu.PermissionId = p.Id " +
                            "where pu.UsersId = '" + user.Id + "')) " +
                            "x group by x.Code";
                    }

                    var permit = _dbDefaultContext.permissionEntities
                         .FromSqlRaw(query).ToList();
                    foreach (var pp in permit)
                    {
                        permits.Add(pp);
                    }
                }

                if (permits.FirstOrDefault() == null)
                {
                    return (true, string.Empty, user, null, -1);
                }

                //perm = _mapper.Map<List<PermissionCodes>>(permits);

                perm = (from a in permits select new PermissionCodes(a.Code) { Code = a.Code }).ToList();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
            int AgId = -1;
            return (true, string.Empty, user, perm, AgId);
        }

        private async Task<User> GetUserAsync(UserEntity userEntity)
        {
            User user = new User();

            try
            {
                // Obtener compañia del usuario
                var queryc = from st in _dbDefaultContext.userCompanyEntities
                             where st.UserId == userEntity.Id && st.estado == true
                             select st;
                var compans = await queryc.Select(g => g.CompanyId).ToListAsync();

                //var compans = await queryc.SingleOrDefaultAsync();

                //var compa = await _context.Company.FindAsync(compans.CompanyId);

                var compa = await _dbDefaultContext.companyEntities.Where(v => compans.Contains(v.Id)).Select(h => h.Id).ToArrayAsync();

                // Obtener roles del usuario
                var query = from st in _dbDefaultContext.userRolesEntities
                            where st.UserId == userEntity.Id && st.Estado == "1"
                            select st;

                var roless = await query.ToListAsync();

                var p = new RoleEntity();

                user = _mapper.Map<User>(userEntity);


                user.Roles = new List<string>();
                user.IdRol = new List<string>();
                foreach (var ro in roless)
                {
                    p = await _dbDefaultContext.Roles.FindAsync(ro.RoleId);
                    // Armar respuesta


                    // role.Name,
                    user.Roles.Add(p.Name);
                    //role.InternalCode


                    //user.IdRol = role.Id;
                    user.IdRol.Add(p.Id);
                    //user.IdCompany = 1;
                    user.IdCompany = compa;
                    //user.IdCompanys = compa;

                }
                user.IdCompany = compa;
                // var roles = await query.SingleOrDefaultAsync();
                // var role = await _context.Roles.FindAsync(roles.RoleId);


            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }

            return user;
        }
    }
}
