using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class AdOrganization
{
    public int Id { get; set; }

    public string OrganizationName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<InvStock> InvStocks { get; set; } = new List<InvStock>();
}
