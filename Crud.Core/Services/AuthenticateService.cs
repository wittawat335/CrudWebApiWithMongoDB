﻿using Crud.Core.DTOs;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.Response;
using Crud.Core.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Core.Operations.ElementNameValidators;
using MongoDB.Driver.Core.WireProtocol.Messages;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthenticateService(UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Response> CreateRole(CreateRoleRequest request)
        {
            var response = new Response();
            try
            {
                var appRole = new ApplicationRole { 
                    RoleCode = request.RoleCode , 
                    Name = request.RoleName, 
                    IsActive = request.IsActive 
                };
                var createRole = await _roleManager.CreateAsync(appRole);

                response.Message = "role created succesfully";
                response.IsSuccess = true;
            }
            catch
            {
                throw;
            }
            return response;
        }

        public async Task<ResponseTable<LoginResponse>> LoginAsync(LoginRequest request, string jwtKey)
        {
            var response = new ResponseTable<LoginResponse>();
            var loginResponse = new LoginResponse();
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid email";
                }
                var verigyResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
                if (verigyResult == PasswordVerificationResult.Failed)
                {
                    //handle invalid login credentials...
                    response.IsSuccess = false;
                    response.Message = "Invalid password";
                }
                else
                {
                    //handle success login...
                    //all is well if ew reach here
                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    };
                    var roles = await _userManager.GetRolesAsync(user);
                    var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x));
                    claims.AddRange(roleClaims);

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var expires = DateTime.Now.AddMinutes(30);

                    var token = new JwtSecurityToken(
                        issuer: "https://localhost:5001",
                        audience: "https://localhost:5001",
                        claims: claims,
                        expires: expires,
                        signingCredentials: creds

                        );
                    loginResponse.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
                    loginResponse.UserId = user?.Id.ToString();
                    loginResponse.Email = user?.Email;

                    response.value = loginResponse;
                    response.IsSuccess = true;
                    response.Message = "Login Successful";
                }
            }
            catch
            {
                throw;
            }

            return response;
        }

        public async Task<Response> RegisterAsync(RegisterRequest request)
        {
            var response = new Response();
            try
            {
                var userExists = await _userManager.FindByEmailAsync(request.Email);
                if (userExists != null)
                {
                    response.IsSuccess = false;
                    response.Message = "ser already exists";
                }
                else
                {
                    userExists = new ApplicationUser
                    {
                        FullName = request.FullName,
                        Email = request.Email,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        UserName = request.Email,

                    };
                    var createUserResult = await _userManager.CreateAsync(userExists, request.Password);
                    if (!createUserResult.Succeeded) 
                    {
                        response.Message = $"Create user failed {createUserResult?.Errors?.First()?.Description}";
                        response.IsSuccess = false;
                    }
                    else
                    {
                        //user is created...
                        //then add user to a role...
                        var addUserToRoleResult = await _userManager.AddToRoleAsync(userExists, "Manager");
                        if (!addUserToRoleResult.Succeeded)
                        {
                            response.Message = $"Create user succeeded but could not add user to role {addUserToRoleResult?.Errors?.First()?.Description}";
                            response.IsSuccess = false;
                        }
                        else
                        {
                            response.Message = "User registered successfully";
                            response.IsSuccess = true; 
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return response;
        }
    }
}
