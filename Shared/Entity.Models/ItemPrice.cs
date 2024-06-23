using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ItemPrice:AuditableEntity<long>
    {

        public long? ItemId { get; set; }

        public decimal? Price { get; set; }

        public bool? IsActive { get; set; }
    }

}
