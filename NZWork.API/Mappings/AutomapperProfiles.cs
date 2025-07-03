using AutoMapper;
using NZWork.API.Model.Domain;
using NZWork.API.Model.DTO;

namespace NZWork.API.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
           
            
        }
    }
}
