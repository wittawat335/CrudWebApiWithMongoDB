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
        public async Task<ResponseTable<ProductDTO>> GetAsync(string code)
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
        public async Task<Response> AddAsync(Products model)
        {
            var response = new Response();
            try
            {
                await _repository.InsertOneAsync(model);
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.Complete;
            }
            catch
            {
                throw;
            }

            return response;
        }
        public async Task<Response> UpdateAsync(ProductDTO model)
        {
            var response = new Response();
            try
            {
                await _repository.ReplaceOneAsync(_mapper.Map<Products>(model));
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.Complete;
            }
            catch
            {
                throw;
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
                response.Message = Constants.Msg.Complete;
            }
            catch
            {
                throw;
            }

            return response;
        }
    }
}
