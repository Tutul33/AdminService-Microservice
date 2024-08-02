using AutoMapper;
using BussinessLogic;
using BussinessLogic.DataRepository;
using BussinessLogic.DomainService;
using Grpc.Core;
using AdminService.Protos;
namespace AdminService
{
    public class OrganizationService : Organization.OrganizationBase
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IOrganizationService _organizationService;
        public OrganizationService(IOrganizationRepository organizationRepository, IOrganizationService organizationService)
        {
            _organizationRepository = organizationRepository;
            _organizationService = organizationService;
        }
        public override async Task<OrganizationReply> GetOrganization(OrganizationRequest request, ServerCallContext context)
        {
            var _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrganizationRequest, OrganizationDTO>();
                cfg.CreateMap<OrganizationDTO, OrganizationReply>();
            }).CreateMapper();

            var org = _mapper.Map<OrganizationDTO>(request);

            var orgRes = await _organizationRepository.Save(org);

            OrganizationReply orgRP = _mapper.Map<OrganizationReply>(orgRes);
            return orgRP;
        }
    }
}
