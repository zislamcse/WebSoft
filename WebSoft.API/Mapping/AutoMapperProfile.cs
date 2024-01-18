using AutoMapper;
using WebSoft.API.Models.Domain;
using WebSoft.API.Models.Dto;

namespace WebSoft.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DtoProductType, ProductTypeModels>().ReverseMap();
            CreateMap<DtoProductTypeAdd, ProductTypeModels>().ReverseMap();
        }
    }
}
