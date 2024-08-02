using System;
using System.Collections.Generic;

namespace Data.DataContext.Models;

public partial class AdMenuPermission
{
    public int Id { get; set; }

    public int? MenuId { get; set; }

    public int? UserId { get; set; }

    public bool? CanCreate { get; set; }

    public bool? CanEdit { get; set; }

    public bool? CanDelete { get; set; }

    public bool? IsActive { get; set; }
}
