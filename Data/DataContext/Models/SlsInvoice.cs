using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class SlsInvoice
{
    public long Id { get; set; }

    public long? ItemId { get; set; }

    public decimal? ItemPrice { get; set; }

    public decimal? SalesPrice { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? LastUpdate { get; set; }
}
