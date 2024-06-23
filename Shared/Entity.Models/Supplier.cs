using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{

    public class Supplier:AuditableEntity<int>
    {

        public string? SupplierName { get; set; }

        public string? Address { get; set; }

        public int? CountryId { get; set; }

        public bool? IsActive { get; set; }
    }
}
