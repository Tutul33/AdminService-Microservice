using AutoMapper;
using Shared;

namespace BussinessLogic.DataRepository
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Organization, OrganizationDTO>();
            CreateMap<OrganizationDTO, Organization>();
            //
        }
    }
}
