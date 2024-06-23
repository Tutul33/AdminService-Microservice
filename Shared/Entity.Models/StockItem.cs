using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class StockItem:RowEntity<long>
    {
        public long? StockId { get; set; }

        public string? LotNo { get; set; }

        public decimal? Qty { get; set; }

        public int? SupplierId { get; set; }

        public DateTime? ExpireDate { get; set; }
    } 

}