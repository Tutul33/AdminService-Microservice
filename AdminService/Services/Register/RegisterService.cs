using AdminService.Protos;
using AutoMapper;
using BussinessLogic;
using BussinessLogic.DataRepository;
using Grpc.Core;

namespace AdminService
{
    public class RegisterService : RegisterUserService.RegisterUserServiceBase
    {
        private readonly IUserRepository _userRepository;
        
        public RegisterService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public DateOnly ResolveStringToDate(RegisterUserRequest source)
        {
            DateTime birthDate;
            if (DateTime.TryParse(source.BirthDate, out birthDate))
            {
                return DateOnly.FromDateTime(birthDate);
            }
            throw new ArgumentException("Invalid date format");
        }
        public string ResolveDateToString(UserDTO source)
        {
            if (source.BirthDate!=null)
            {
                return Convert.ToDateTime(source.BirthDate).ToShortDateString();
            }
            throw new ArgumentException("Invalid date format");
        }
        public override async Task<RegisterUserReply> RegisterUser(RegisterUserRequest request, ServerCallContext context)
        {
            try
            {
                var _mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RegisterUserRequest, UserDTO>()
                       .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => ResolveStringToDate(src))); 
                    cfg.CreateMap<UserDTO, RegisterUserReply>()
                     .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToString())); 
                }).CreateMapper();

                var user = _mapper.Map<UserDTO>(request);

                var userRes = await _userRepository.Save(user);

                RegisterUserReply userDTO = _mapper.Map<RegisterUserReply>(userRes);

                return userDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
