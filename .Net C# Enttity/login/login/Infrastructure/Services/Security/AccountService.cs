using AutoMapper;
using login.Data;
using login.Data.Entities;
using login.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

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

        public Task<(bool Success, string Message, User User, List<PermissionCodes> Permissions, int AdId)> Login(string UserName, string Password, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
