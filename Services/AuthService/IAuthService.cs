using Microsoft.AspNetCore.Mvc;
using tech_store.Dtos.Address;
using tech_store.Dtos.User;

namespace tech_store.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<UserGetDto>> registerUser(UserAddDto userParams);
        Task<UserGetDto> loginUser(string username, string password);
        Task<ServiceResponse<AddressGetDto>> addAddress(AddressAddDto addressParams);

        Task<ServiceResponse<bool>> userExists(string username);
   
    }
}
