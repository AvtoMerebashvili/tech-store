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
using tech_store.Filters;
using tech_store.Services.AuthService;
using tech_store.Services.TokenService;

namespace tech_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("RegisterUser")]
        public async Task<ServiceResponse<UserGetDto>> registerUser(UserAddDto userParams){
            return await _authService.registerUser(userParams);
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult<User>> logIn(string username, string password)
        {
            var userDb = await _authService.loginUser(username, password);
            if (userDb == null)
            {
                return Unauthorized();
            }

            var token = _tokenService.generateToken(userDb);

            return Ok(new
            {
                token,
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
        [HttpGet("Addresses")]
        public async Task<ServiceResponse<List<AddressGetDto>>> getAddress() 
        {
        return await _authService.getAddresses();
        }

        [Authorize]
        [RoleFilter("admin,moderator")]
        [HttpGet("Roles")]
        public async Task<ServiceResponse<List<RolesGetDto>>> getRoles(int? id)
        {
            return await _authService.getRoles(id);
        }

        [Authorize]
        [RoleFilter("admin")]
        [HttpPost("AddRole")]
        public async Task<ServiceResponse<List<RolesGetDto>>> addRole(RolesAddDto role)
        {
            return await _authService.addRole(role);
        }

    }
}
