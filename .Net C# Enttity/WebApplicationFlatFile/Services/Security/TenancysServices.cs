using AccountControl.Data;
using AccountControl.Resx;
using AccountControll.Data.Entities;
using AccountControll.Dtos;
using AccountControll.Dtos.Account;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountControll.Services.Security
{
    public class TenancysServices : ITenancysServices
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly TecSolGroupDbContext _dbContext;

        public TenancysServices(IMapper mapper, IConfiguration configuration, TecSolGroupDbContext dbContext)
        {
            _mapper = mapper;
            _configuration = configuration;
            _dbContext = dbContext;
        }
        public async Task<(bool Succeeded, string Message)> Create(AdmTenancysEntity Tenancys)
        {
            try
            {
                _dbContext.admTenancysEntities.Add(Tenancys);
                await _dbContext.SaveChangesAsync();
                return (true, DomainMsg.Success);
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                return (false, ex.Message);
            }
        }
        public async Task<(bool Succeeded, string Message, Response<List<AdmTenancysEntity>> response)> GetAll(PaginationFilter filter)
        {
            try
            {
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var pagedData = await _dbContext.admTenancysEntities.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToListAsync();
                var totalRecords = await _dbContext.admTenancysEntities.CountAsync();
                return (true, null, new PagedResponse<List<AdmTenancysEntity>>(pagedData, validFilter.PageNumber, validFilter.PageSize));

            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
    }
}
