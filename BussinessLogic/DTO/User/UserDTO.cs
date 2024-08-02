using Shared;
using System.ComponentModel.DataAnnotations;

namespace BussinessLogic
{
    public class UserDTO:User
    {
        [Required]
        public string UserName { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
    }
}
