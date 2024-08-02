using AdminService.Protos;
using MediatR;

namespace AdminService.Requests
{
    public class SetRegisterUserRequest : IRequest<RegisterUserReply>
    {
        public string? FullName { get; set; }

        public short? Age { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? BirthTime { get; set; }

        public string? Address { get; set; }

        public string? Country { get; set; }
    }
}
