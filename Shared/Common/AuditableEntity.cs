using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AuditableEntity<T> : IIdentity<T?>
    {
        public T? Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public long? CreatedBy { get; set; }
        public long? LastUpdatedBy { get; set; }
    }
}
