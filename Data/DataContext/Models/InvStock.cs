using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class InvStock
{
    public long Id { get; set; }

    public int? OrgId { get; set; }

    public long? ItemId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdate { get; set; }

    public virtual InvItem? Item { get; set; }

    public virtual AdOrganization? Org { get; set; }
}
