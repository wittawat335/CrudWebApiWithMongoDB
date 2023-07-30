using Crud.Core.DTOs;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.Response;

namespace Crud.Core.Services.Contracts
{
    public interface IProductService
    {
        Task<ResponseList<ProductDTO>> GetAllAsync();
        Task<ResponseTable<ProductDTO>> GetAsync(string code);
        Task<Response> AddAsync(Products model);
        Task<ResponseTable<ProductDTO>> GetByIdAsync(string id);
        Task<Response> UpdateAsync(ProductDTO model);
        Task<Response> DeleteByIdAsync(string id);
    }
}
