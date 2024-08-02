using BussinessLogic;
using BussinessLogic.DataRepository;
using BussinessLogics;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors()]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
                _userRepository= userRepository;
        }

        /// <summary>
        /// This methods will store data to database 
        /// </summary>
        /// <param name="organizationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserLogin")]
        public async Task<UserDTO> UserLogin([FromBody] UserLoginDTO userLogin)
        {
            try
            {
                return await _userRepository.UserLogin(userLogin);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// This methods will store data to database 
        /// </summary>
        /// <param name="organizationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<UserDTO> Register([FromBody] UserDTO user)
        {
            try
            {
                return await _userRepository.Save(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
