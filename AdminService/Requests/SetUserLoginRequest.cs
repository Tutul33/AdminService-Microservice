using MediatR;
using AdminService.Protos;
namespace AdminService.Requests
{
    public class SetUserLoginRequest : IRequest<UserLoginReply>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
