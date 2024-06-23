using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class UserLogin : AuditableEntity<long>
    {
        public long? UserId { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public bool? IsActive { get; set; }

    }

}
