using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Invoice:AuditableEntity<long>
    {
        public long? ItemId { get; set; }

        public decimal? ItemPrice { get; set; }

        public decimal? SalesPrice { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsActive { get; set; }

    }

}
