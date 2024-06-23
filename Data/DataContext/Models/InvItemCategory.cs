using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class InvItemCategory
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<InvItem> InvItems { get; set; } = new List<InvItem>();
}
