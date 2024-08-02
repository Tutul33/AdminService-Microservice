using AdminService.Requests;
using AutoMapper;
using BussinessLogic;
using BussinessLogic.DataRepository;
using BussinessLogic.DomainService;
using MediatR;
using AdminService.Protos;

namespace AdminService.Handler
{
    public class GetOrganizationHandler : IRequestHandler<GetOrganizationRequest, OrganizationReply>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IOrganizationService _organizationService;
        public GetOrganizationHandler(IOrganizationRepository organizationRepository, IOrganizationService organizationService)
        {
            _organizationRepository = organizationRepository;
            _organizationService = organizationService;
        }
        public async Task<OrganizationReply> Handle(GetOrganizationRequest request, CancellationToken cancellationToken)
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
