using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class RowEntity<T>:IIdentity<T>
    {
        public int? tag { get; set; }
        public T? Id { get ; set; }
        public bool? IsActive { get; set; }
    }
}
