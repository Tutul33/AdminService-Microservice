using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Organization:AuditableEntity<int>
    {
        public string? OrganizationName { get; set; }

        public bool? IsActive { get; set; }
    }
}
