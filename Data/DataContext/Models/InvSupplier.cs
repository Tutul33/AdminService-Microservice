using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class InvSupplier
{
    public int Id { get; set; }

    public string? SupplierName { get; set; }

    public string? Address { get; set; }

    public int? CountryId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdate { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }
}
