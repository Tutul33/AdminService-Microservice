using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Item:AuditableEntity<long>
    {
        public string? ItemName { get; set; }

        public int? CategoryId { get; set; }

        public string? IsActive { get; set; }

  }

}
