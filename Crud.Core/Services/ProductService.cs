using AutoMapper;
using Crud.Core.Domain.RepositoryContract;
using Crud.Core.DTOs;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.Response;
using Crud.Core.Services.Contracts;
using Crud.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoRepository<Products> _repository;
        private readonly IMapper _mapper;

        public ProductService(IMongoRepository<Products> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseList<ProductDTO>> GetAllAsync()
        {
            var response = new ResponseList<ProductDTO>();
            try
            {
                var list = await _repository.GetAll();
                response.data = _mapper.Map<List<ProductDTO>>(list);
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.GetList;
            }
            catch
            {
                throw;
            }

            return response;
        }
        public ResponseList<ProductDTO> GetListByCreateBy(string filter)
        {
            var response = new ResponseList<ProductDTO>();
            try
            {
                var list = _repository.FilterBy(x => x.CreateBy == filter);
                response.data = _mapper.Map<List<ProductDTO>>(list);
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.GetList;
            }
            catch
            {
                throw;
            }

            return response;
        }
        public async Task<ResponseTable<ProductDTO>> GetOneAsync(string code)
        {
            var response = new ResponseTable<ProductDTO>();
            try
            {
                var model = await _repository.FindOneAsync(x => x.ProductName == code);
                response.value = _mapper.Map<ProductDTO>(model);
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.GetList;
            }
            catch
            {
                throw;
            }
            return response;
        }
        public async Task<ResponseTable<ProductDTO>> GetByIdAsync(string id)
        {
            var response = new ResponseTable<ProductDTO>();
            try
            {
                var model = await _repository.FindByIdAsync(id);
                response.value = _mapper.Map<ProductDTO>(model);
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.GetList;
            }
            catch
            {
                throw;
            }
            return response;
        }
        public async Task<Response> AddAsync(ProductInput model)
        {
            var response = new Response();
            try
            {               
                await _repository.InsertOneAsync(_mapper.Map<Products>(model));
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.InsertComplete;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
        public async Task<Response> UpdateAsync(ProductDTO model)
        {
            var response = new Response();
            try
            {
                var findId = _repository.FindById(model.Id);

                await _repository.ReplaceOneAsync(_mapper.Map(model, findId));
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.UpdateComplete;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
        public async Task<Response> DeleteByIdAsync(string id)
        {
            var response = new Response();
            try
            {
                await _repository.DeleteByIdAsync(id);
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.DeleteComplete;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

       
        public async Task<Response> DeleteListAsyncByCreateBy(string text)
        {
            var response = new Response();
            try
            {
                await _repository.DeleteManyAsync(x => x.CreateBy == text);
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.DeleteComplete;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
    }
}
