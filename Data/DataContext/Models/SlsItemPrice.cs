using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class SlsItemPrice
{
    public long Id { get; set; }

    public long? ItemId { get; set; }

    public decimal? Price { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? LastUpdate { get; set; }

    public long? LastUpdatedBy { get; set; }
}
