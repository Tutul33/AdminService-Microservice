using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class AdMenu
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ParentMenuId { get; set; }

    public string? Icon { get; set; }

    public string? Url { get; set; }

    public bool? IsActive { get; set; }
}
