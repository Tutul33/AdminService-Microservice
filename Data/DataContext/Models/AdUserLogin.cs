using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class AdUserLogin
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdate { get; set; }

    public virtual ICollection<AdUserLogin> InverseUser { get; set; } = new List<AdUserLogin>();

    public virtual AdUserLogin? User { get; set; }
}
