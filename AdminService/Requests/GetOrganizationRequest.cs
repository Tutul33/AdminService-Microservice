using MediatR;
using AdminService.Protos;

namespace AdminService.Requests
{
    public class GetOrganizationRequest:IRequest<OrganizationReply>
    {
        public string? OrganizationName { get; set; }
        public bool IsActive { get; set; }
    }

}
