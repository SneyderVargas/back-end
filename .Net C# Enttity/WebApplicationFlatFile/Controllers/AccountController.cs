using AccountControl.Services.Security;
using AccountControll.Data.Entities;
using AccountControll.Dtos;
using AccountControll.Dtos.Account;
using AccountControll.Services.Security;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel.Channels;

namespace AccountControll.Controllers
{
    //[Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountServices _accountServices;
        private readonly IJwtGenerator _jwtGenerator;

        public AccountController(IMapper mapper, IAccountServices accountServices, IJwtGenerator jwtGenerator)
        {
            _mapper = mapper;
            _accountServices = accountServices;
            _jwtGenerator = jwtGenerator;
        }
        public async Task<IActionResult> CreateAdmUser([FromBody] CreateAdmUserDto param)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorDto(ModelState));

        }
        [HttpGet]
        public async Task<IActionResult> GetAllAdmUsers()
        {
            //[StringLength(256, ErrorMessage = SecurityMsg.UserNameLengthValidation, MinimumLength = 5)]
            //public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequestDto request, CancellationToken ct)
            //if (!ModelState.IsValid)
            //    return BadRequest(new ApiErrorDto(ModelState));

            try
            {
                var (Succeeded, Message, Users) = await _accountServices.GetAllAdmUsers();

                if (Succeeded == false)
                {
                    return Ok(ApiCollectionResponseDto.CreateOk(Message, null, 0));
                }
                else
                {
                    var user = _mapper.Map<List<AdmUserDto>>(Users);
                    return Ok(ApiCollectionResponseDto.Create(user.Count, user.ToArray()));
                }
            }
            catch(Exception ex)
            {
                //return BadRequest(new ApiErrorDto(ModelState));
                var err = ex;
                return Ok(ApiCollectionResponseDto.CreateOk(err.Message, null, 0));
            }

            

        }

    }
}
