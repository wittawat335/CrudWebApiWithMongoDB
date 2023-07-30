using AutoMapper;
using Crud.Core.DTOs;
using Crud.Core.Model.MongoDB.Collections;
using MongoDB.Bson;

namespace Crud.Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Products
            CreateMap<Products, ProductDTO>().ForMember(
               x => x.Id,
               opt => opt.MapFrom(origin => origin.Id.ToString()));
            CreateMap<ProductDTO, Products>().ForMember(
                x => x.Id,
                opt => opt.MapFrom(origin => new ObjectId(origin.Id)));
            #endregion

        }
    }
}
