using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class UserContactAddress:RowEntity<int>
    {
        public int UserId { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
    }
}
