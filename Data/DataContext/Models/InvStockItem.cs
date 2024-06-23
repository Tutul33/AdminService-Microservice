using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class InvStockItem
{
    public long Id { get; set; }

    public long? StockId { get; set; }

    public string? LotNo { get; set; }

    public decimal? Qty { get; set; }

    public int? SupplierId { get; set; }

    public DateTime? ExpireDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdate { get; set; }

    public long? LastUpdatedBy { get; set; }
}
