using Crud.Core.DTOs;
using Crud.Core.Model.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Services.Contracts
{
    public interface IAuthenticateService
    {
        Task<ResponseTable<LoginResponse>> LoginAsync(LoginRequest request);
        Task<Response> RegisterAsync(RegisterRequest request);
        Task<Response> CreateRole(CreateRoleRequest request);
    }
}
