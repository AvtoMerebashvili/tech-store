﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tech_store.DbModels;
using tech_store.DbModels.Auth;
using tech_store.Dtos.Address;
using tech_store.Dtos.Roles;
using tech_store.Dtos.User;

namespace tech_store.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly TechStoreContext _context;
        private readonly IMapper _mapper;
        public AuthService(TechStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        async public Task<ServiceResponse<AddressGetDto>> addAddress(AddressAddDto addressParams)
        {
            throw new NotImplementedException();
        }

        async public Task<UserGetDto> loginUser(string username, string password)
        {
            var user = await _context.users.FirstOrDefaultAsync(dbUser => dbUser.username == username);

            if (user == null)
            {
                return null;

            }

            if (!verifyPasswHash(password, user.passwordHash, user.passwordSalt))
            {
                return null;

            }

            return _mapper.Map<UserGetDto>(user);

        }

        async public Task<ServiceResponse<UserGetDto>> registerUser(UserAddDto userParams)
        {
            var response = new ServiceResponse<UserGetDto>();
            var userAlreadyExists = await userExists(userParams.surname);

            if (userAlreadyExists.result)
            {

                response.success = false;
                response.message = "User Already exists";
                return response;
            }

            byte[] passwHash, passwSalt;
            createPasswordHash(userParams.password, out passwHash, out passwSalt);
            User user = _mapper.Map<User>(userParams);
            user.passwordHash = passwHash;
            user.passwordSalt = passwSalt;

            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();

            response.result = _mapper.Map<UserGetDto>(user);
            return response;

        }

        async public Task<ServiceResponse<bool>> userExists(string username)
        {
            var response = new ServiceResponse<bool>();
            response.result = await _context.users.AnyAsync(x => x.username == username);
            return response;
        }

        async public Task<ServiceResponse<List<RolesGetDto>>> getRoles(int? id)
        {
            var response = new ServiceResponse<List<RolesGetDto>>();

            var dbRole = await _context.roles.Where(role =>
                   string.IsNullOrEmpty(id.ToString()) || role.id == id
                   ).ToListAsync();

            var rolesGetDto = dbRole.Select(x => _mapper.Map<RolesGetDto>(x)).ToList();
            response.result = rolesGetDto;
            return response;
        }

        async public Task<ServiceResponse<List<RolesGetDto>>> addRole(RolesAddDto role)
        {
            var response = new ServiceResponse<List<RolesGetDto>>();

            //var exists = _context.roles.FirstOrDefaultAsync(x => x.id == role.id);
            //if(exists ) { }

            var dbRole = _mapper.Map<Role>(role);
            await _context.AddAsync(dbRole);
            await _context.SaveChangesAsync();
            var dbRoles = _context.roles.ToList();
            var rolesGetDto = dbRoles.Select(x => _mapper.Map<RolesGetDto>(x)).ToList();
            response.result = rolesGetDto;
            return response;
        }

        private bool verifyPasswHash(string password, byte[] passwHash, byte[] passwSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwSalt)) 
            { 
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwHash[i]) return false;
                } 
            }
            return true;
        }

        private void createPasswordHash(string password, out byte[] passwHash, out byte[] passwSalt) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwSalt = hmac.Key;
                passwHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}