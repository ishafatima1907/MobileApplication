
namespace MobileApplication.Manager.Profile
{
    using MobileApplication.Manager.DTOs;
    using MobileApplication.DbModels;
    using AutoMapper;
    public class MappingProfiler : Profile
    {
            public MappingProfiler()
            {
               CreateMap<MobileInfo, MobileInfoDto>().ReverseMap().ReverseMap();
               CreateMap<MobileSpec, MobileSpecsDto>().ReverseMap().ReverseMap();
               CreateMap<MobileInfo, MobileInfoCreateUpdateDto>().ReverseMap();
            }
        
    }
}
