using AdminService.Protos;
using AutoMapper;
using BussinessLogic.DataRepository;
using BussinessLogic.DomainService;
using BussinessLogic;
using Grpc.Core;
using BussinessLogics;

namespace AdminService
{
    public class LoginService : UserLogin.UserLoginBase
    {
        private readonly IUserRepository _userRepository;
        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public override async Task<UserLoginReply> SetUserLogin(UserLoginRequest request, ServerCallContext context)
        {
            try
            {
                var _mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserLoginRequest, UserLoginDTO>();
                    cfg.CreateMap<UserDTO, UserLoginReply>()
                    .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate!=null?src.BirthDate.ToString():""));
                }).CreateMapper();

                var user = _mapper.Map<UserLoginDTO>(request);

                var userRes = await _userRepository.UserLogin(user);

                UserLoginReply userDTO = _mapper.Map<UserLoginReply>(userRes);

                return userDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
