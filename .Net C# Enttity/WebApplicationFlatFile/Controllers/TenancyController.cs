using AccountControl.Services.Security;
using AccountControll.Data.Entities;
using AccountControll.Dtos.Account;
using AccountControll.Dtos;
using AccountControll.Services.Security;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AccountControll.Controllers
{
    //[Authorize]
    [Route("[controller]/[action]")]
    public class TenancyController: Controller
    {
        private readonly IMapper _mapper;
        private readonly ITenancysServices _tenancysServices;
        private readonly IJwtGenerator _jwtGenerator;

        public TenancyController(IMapper mapper, ITenancysServices tenancysServices, IJwtGenerator jwtGenerator)
        {
            _mapper = mapper;
            _tenancysServices = tenancysServices;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTenancys([FromBody] CreateAdmTenancysRequest param)
        {
            try
            {
                AdmTenancysEntity data = _mapper.Map<AdmTenancysEntity>(param);
                if (!ModelState.IsValid)
                    return BadRequest(new ApiErrorDto(ModelState));
                var (Succeeded, Message) = await _tenancysServices.Create(data);
                return Ok(ApiCollectionResponseDto.CreateOk(Message, null, 0));
            }
            catch (Exception ex)
            {
                var err = ex;
                return Ok(ApiCollectionResponseDto.CreateOk(err.Message, null, 0));
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetAllTenancys([FromQuery] PaginationFilter filter)
        {
            try
            {
                var (Succeeded, Message, Response) = await _tenancysServices.GetAll(filter);

                if (Succeeded == false)
                {
                    return Ok(ApiCollectionResponseDto.CreateOk(Message, null, 0));
                }
                else
                {
                    //var data = _mapper.Map<List<AdmTenancysDto>>(Data);
                    //return Ok(ApiCollectionResponseDto.Create(data.Count, data.ToArray()));
                    return Ok(Response);
                }
            }
            catch (Exception ex)
            {
                //return BadRequest(new ApiErrorDto(ModelState));
                var err = ex;
                return Ok(ApiCollectionResponseDto.CreateOk(err.Message, null, 0));
            }

        }
    }
}
