using AutoMapper;
using login.Dtos.Infrastructure;
using login.Dtos.Security;
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
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorDto(ModelState));
            var (succeeded, message, user, permits, AgId) = await _accountService.Login(request.UserName, request.Password, ct);
            return null;
        }
    }
}
