using AutoMapper;
using login.Dtos.Infrastructure;
using login.Dtos.Security;
using login.Infrastructure.Helpers;
using login.Infrastructure.Models;
using login.Infrastructure.Services.Security;
using login.Resx;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace login.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IJwtGenerator _tokenService;

        public AccountController(IMapper mapper, IAccountService accountService, IJwtGenerator tokenService)
        {
            _mapper = mapper;
            _accountService = accountService;
            _tokenService = tokenService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request, CancellationToken ct)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiErrorDto(ModelState));
                var (succeeded, message, user, permits, AgId) = await _accountService.Login(request.UserName, request.Password, ct);
                if (!succeeded || user == null)
                {
                    return BadRequest(new ApiErrorDto
                    {
                        Message = SecurityMsg.AccountLoginError,
                        Detail = message
                    });
                }
                var token = _tokenService.GenerateToken(user.Id, user.UserName);

                if (token == null)
                {
                    return BadRequest(new ApiErrorDto
                    {
                        Message = SecurityMsg.AccountLoginError,
                        Detail = SecurityMsg.TokenError
                    });
                }
                var userDto = _mapper.Map<UserDto>(user);

                List<PermissionCodes> userPermits = new List<PermissionCodes>();
                if (permits != null)
                {
                    CryptoUtils crypto = new CryptoUtils();
                    foreach (var permmit in permits)
                    {
                        userPermits.Add(new PermissionCodes(crypto.Encrypt(permmit.Code, token.ToString())));
                    }
                }

                var result = new LoginResponseDto
                {
                    User = userDto,
                    Token = token,
                    Permits = userPermits,
                    AgId = AgId
                };

                //_ = typeof(AccountController).Assembly.GetName().Version;

                var Version_ = typeof(AccountController).Assembly.GetName().Version;




                result.User.NumDocument = user.NumDocument;
                result.User.Version = "Versión " + Version_.ToString();



                return Ok(result);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout([FromBody] LogoutRequestDto request, CancellationToken ct)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiErrorDto(ModelState));

                var (succeeded, message) = await _accountService.LogoutAsync(request.UserName, ct);
                if (!succeeded)
                {
                    return BadRequest(new ApiErrorDto
                    {
                        Message = SecurityMsg.AccountLoginError,
                        Detail = message
                    });
                }

                return Ok(new ApiSingleResponseDto(message));
            }
            catch (Exception ex)
            {
                var e = ex.Message;
                return null;
            }
        }
    }
}
