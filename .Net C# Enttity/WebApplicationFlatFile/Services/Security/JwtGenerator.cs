using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AccountControl.Data.Entities;
using AccountControl.Dtos.Security;

namespace AccountControl.Services.Security
{
    public class JwtGenerator: IJwtGenerator
    {
        private readonly IConfiguration _configuration;
        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenDto CreateToken(UserEntity user, List<string> roles)
        {
            var gt = Convert.ToInt32(_configuration["LogInTimeoutMinutes"]);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };
            //Se agrega los roles como claims dentro del Token.
            if (roles != null)
            {
                foreach (var rol in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }
            }
            var expiresDate = DateTime.Now.AddDays(1);

            var expiresIn = expiresDate.Ticks / TimeSpan.TicksPerMillisecond;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["MyLetterSecret"]));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescripcion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiresDate,
                SigningCredentials = credenciales
            };

            var tokenManejador = new JwtSecurityTokenHandler();
            var token = tokenManejador.CreateToken(tokenDescripcion);



            var tok = new TokenDto()
            {
                Auth_token = tokenManejador.WriteToken(token),
                Expires_In = expiresIn
            };



            return tok;
        }

        public TokenDto GenerateToken(string userId, string userName)
        {
            var gt = Convert.ToInt32(_configuration["LogInTimeoutMinutes"]);



            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.NameId, userName)
            };

            //Se agrega los roles como claims dentro del Token.
            //if (roles != null)
            //{
            //    foreach (var rol in roles)
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, rol));
            //    }
            //}


            var expiresDate = DateTime.Now.AddDays(1);

            var expiresIn = expiresDate.Ticks / TimeSpan.TicksPerMillisecond;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["MyLetterSecret"]));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescripcion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiresDate,
                SigningCredentials = credenciales
            };

            var tokenManejador = new JwtSecurityTokenHandler();
            var token = tokenManejador.CreateToken(tokenDescripcion);



            var tok = new TokenDto()
            {
                Auth_token = tokenManejador.WriteToken(token),
                Expires_In = expiresIn
            };



            return tok;
        }
    }
}
