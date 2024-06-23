using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class User:AuditableEntity<long>
    {
        public string? FullName { get; set; }

        public short? Age { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? BirthTime { get; set; }

        public string? Address { get; set; }

        public string? Country { get; set; }

        public bool? IsActive { get; set; }
        
    }

}
