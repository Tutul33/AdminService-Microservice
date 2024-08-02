using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class AdUser
{
    public long Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public short? Age { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? BirthTime { get; set; }

    public string? Address { get; set; }

    public string? Country { get; set; }

    public bool? TermsAndConditions { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdate { get; set; }

    public long? LastUpdatedBy { get; set; }
}
