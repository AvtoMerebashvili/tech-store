using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tech_store.DbModels;
using tech_store.DbModels.Auth;
using tech_store.Dtos.Address;
using tech_store.Dtos.Roles;
using tech_store.Dtos.User;
using tech_store.Services.AuthService;

namespace tech_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public AuthController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }

        [HttpPost("RegisterUser")]
        public async Task<ServiceResponse<UserGetDto>> registerUser(UserAddDto userParams){
            return await _authService.registerUser(userParams);
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult<UserGetDto>> logIn(string username, string password)
        {
            var userDb = await _authService.loginUser(username, password);

            if(userDb == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userDb.id.ToString()),
                new Claim(ClaimTypes.Name, userDb.username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token),
                userDb
            });
        }

        [Authorize]
        [HttpPost("AddAddress")]
        public async Task<ServiceResponse<AddressGetDto>> addAddress(AddressAddDto addressParams)
        {
            return await _authService.addAddress(addressParams);
        }
        [Authorize]
        [HttpDelete("RemoveAddress")]
        public async Task<ServiceResponse<bool>> removeAddress(int id)
        {
            return await _authService.removeAddress(id);
        }

        [Authorize]
        [HttpGet("GetAddress")]
        public async Task<ServiceResponse<List<AddressGetDto>>> getAddress() 
        {
        return await _authService.getAddresses();
        }

        [Authorize]
        [HttpGet]
        [Route("Roles")]
        public async Task<ServiceResponse<List<RolesGetDto>>> getRoles(int? id)
        {
            return await _authService.getRoles(id);
        }

        [Authorize] 
        [HttpPost]
        [Route("AddRole")]
        public async Task<ServiceResponse<List<RolesGetDto>>> addRole(RolesAddDto role)
        {
            return await _authService.addRole(role);
        }

    }
}
