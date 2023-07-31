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
            CreateMap<Products, ProductDTO>() //Output 
                .ForMember(x => x.Id, opt => opt.MapFrom(origin => origin.Id.ToString()));
            CreateMap<ProductDTO, Products>() //Input
                .ForMember(x => x.Id, opt => opt.MapFrom(origin => new ObjectId(origin.Id)))
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(origin => DateTime.Now));
            #endregion

        }
    }
}
