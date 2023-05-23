using AutoMapper;
using login.Infrastructure.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace login.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController: Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IMapper mapper, IAccountService accountService, ITokenService tokenService)
        {
            _mapper = mapper;
            _accountService = accountService;
            _tokenService = tokenService;
        }
    }
}
