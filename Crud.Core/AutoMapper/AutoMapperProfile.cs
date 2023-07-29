using AutoMapper;
using Crud.Core.DTOs;
using Crud.Core.Model.MongoDB.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Role, RoleDTO>().ForMember(
                x => x.Id,
                opt => opt.MapFrom(origin => origin.Id.ToString()));
            CreateMap<RoleDTO, Role>().ForMember(
                x => x.Id,
                opt => opt.Ignore());
        }
    }
}
