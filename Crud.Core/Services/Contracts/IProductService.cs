using Crud.Core.DTOs;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.Response;

namespace Crud.Core.Services.Contracts
{
    public interface IProductService
    {
        Task<ResponseList<ProductDTO>> GetAllAsync();
        ResponseList<ProductDTO> GetListByCreateBy(string filter);
        Task<ResponseTable<ProductDTO>> GetOneAsync(string code);
        Task<Response> AddAsync(ProductInput model);
        Task<ResponseTable<ProductDTO>> GetByIdAsync(string id);
        Task<Response> UpdateAsync(ProductDTO model);
        Task<Response> DeleteByIdAsync(string id);
        Task<Response> DeleteListAsyncByCreateBy(string text);
    }
}
