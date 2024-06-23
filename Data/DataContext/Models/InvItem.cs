using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class InvItem
{
    public long Id { get; set; }

    public string? ItemName { get; set; }

    public int? CategoryId { get; set; }

    public string? IsActive { get; set; }

    public virtual InvItemCategory? Category { get; set; }

    public virtual ICollection<InvStock> InvStocks { get; set; } = new List<InvStock>();
}
