using BussinessLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DataRepository
{
    public interface IUserRepository
    {
        Task<UserDTO> Save(UserDTO User);
        Task<UserDTO> UserLogin(UserLoginDTO User);
        Task<bool> Delete(int id);
    }
}
