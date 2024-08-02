using AdminService.Protos;
using AdminService.Requests;
using BussinessLogic.DataRepository;
using BussinessLogic.DomainService;
using MediatR;

namespace AdminService.Handler
{
    public class SetRegisterUserHandler : IRequestHandler<SetRegisterUserRequest, RegisterUserReply>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IOrganizationService _organizationService;
        public SetRegisterUserHandler(IOrganizationRepository organizationRepository, IOrganizationService organizationService)
        {
            _organizationRepository = organizationRepository;
            _organizationService = organizationService;
        }
        public async Task<RegisterUserReply> Handle(SetRegisterUserRequest request, CancellationToken cancellationToken)
        {
            //var _mapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<OrganizationRequest, OrganizationDTO>();
            //    cfg.CreateMap<OrganizationDTO, OrganizationReply>();
            //}).CreateMapper();

            //var org = _mapper.Map<OrganizationDTO>(request);

            //var orgRes = await _organizationRepository.Save(org);

            //OrganizationReply orgRP = _mapper.Map<OrganizationReply>(orgRes);
            return new RegisterUserReply();
        }
    }
}
