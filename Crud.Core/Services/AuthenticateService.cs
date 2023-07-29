using Crud.Core.DTOs;
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

        public AuthenticateService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Response> CreateRole(CreateRoleRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseTable<LoginResponse>> LoginAsync(LoginRequest request)
        {
            var response = new ResponseTable<LoginResponse>();
            var loginResponse = new LoginResponse();
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid email/password";
                }
                else
                {
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

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1swek3u4uo2u4a6e"));
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
                }
                response.value = loginResponse;
                response.IsSuccess = true;
                response.Message = "Login Successful";
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
                        var addUserToRoleResult = await _userManager.AddToRoleAsync(userExists, "USER");
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
