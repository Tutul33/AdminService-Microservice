using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Stock:AuditableEntity<long>
    {

        public int? OrgId { get; set; }

        public long? ItemId { get; set; }

        public bool? IsActive { get; set; }
     }

}
