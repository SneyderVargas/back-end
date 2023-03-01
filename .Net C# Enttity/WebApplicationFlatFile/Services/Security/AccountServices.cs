using AccountControl.Data;
using AccountControl.Resx;
using AccountControll.Data.Entities;
using AccountControll.Dtos.Account;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountControll.Services.Security
{
    public class AccountServices : IAccountServices
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly TecSolGroupDbContext _dbContext;

        public AccountServices(IMapper mapper, IConfiguration configuration, TecSolGroupDbContext dbContext)
        {
            _mapper = mapper;
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<(bool Success, string Message)> CreateAdmUser(AdmUsersEntity User)
        {
            List<AdmUsersEntity> users = new List<AdmUsersEntity>();
            try
            {
                users = await _dbContext.admUsersEntities.Where(x => x.Email == User.Email && x.Tenancys == User.Tenancys).ToListAsync();
                if (users.Count <= 0)
                    return (false, DomainMsg.CreateAdmUserExist.ToString());
                using (var transac = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        _dbContext.admUsersEntities.Add(User);
                        await _dbContext.SaveChangesAsync();
                        transac.Commit();
                        return (true, DomainMsg.Success);
                    }
                    catch (Exception ex)
                    {
                        //throw new Exception(ex.Message);
                        transac.Rollback();
                        return (false, ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool Succeeded, string Message, List<AdmUsersEntity> Users)> GetAllAdmUsers()
        {
            List<AdmUsersEntity> users = new List<AdmUsersEntity>();
            try
            {
                users = await _dbContext.admUsersEntities.ToListAsync();
                return (true, null, users);
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                return (false, ex.Message, null);
            }
            
        }
    }
}
