using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class AdUserContactAddress
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? ContactNo { get; set; }

    public string? Address { get; set; }

    public bool? IsActive { get; set; }
}
