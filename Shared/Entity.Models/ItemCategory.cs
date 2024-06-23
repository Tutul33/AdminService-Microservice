using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ItemCategory : AuditableEntity<long>
    {
        public string? CategoryName { get; set; }
    }
}
