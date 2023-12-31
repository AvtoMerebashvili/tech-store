﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using tech_store.DbModels.Auth;
using tech_store.Dtos.Address;
using tech_store.Dtos.Roles;
using tech_store.Dtos.User;

namespace tech_store.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<UserGetDto>> registerUser(UserAddDto userParams);
        Task<User> loginUser(string username, string password);
        Task<ServiceResponse<AddressGetDto>> addAddress(AddressAddDto addressParams);
        Task<ServiceResponse<bool>> removeAddress(int id);
        Task<ServiceResponse<List<AddressGetDto>>> getAddresses();
        Task<ServiceResponse<bool>> userExists(string username);
        Task<ServiceResponse<List<RolesGetDto>>> getRoles(int? id);
        Task<ServiceResponse<List<RolesGetDto>>> addRole(RolesAddDto role);

    }
}
