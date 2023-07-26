using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tech_store.DbModels.Auth;

namespace tech_store.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly string _sectionName = "AppSettings:Token";
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenService(IConfiguration config, IHttpContextAccessor contextAccessor) 
        {
            _config = config;
            _contextAccessor = contextAccessor;
        }
        public string generateToken(User userDb)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userDb.id.ToString()),
                new Claim(ClaimTypes.Name, userDb.username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection(_sectionName).Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string getStrUserId()
        {
            string accessToken = _contextAccessor.HttpContext.Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(accessToken.Replace("Bearer ", ""));
            return jwtSecurityToken.Claims.First(claim => claim.Type == "nameid").Value;
        }

        public int getUserId()
        {
            string accessToken = _contextAccessor.HttpContext.Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(accessToken.Replace("Bearer ", ""));
            var strUserId = jwtSecurityToken.Claims.First(claim => claim.Type == "nameid").Value;
            return Convert.ToInt32(strUserId);
        }
   
    }
}
