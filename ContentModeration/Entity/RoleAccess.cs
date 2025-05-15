using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class RoleAccess
{
    public string? DescriptionRu { get; set; }

    public string? DescriptionKk { get; set; }

    public string? DescriptionEn { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid RoleAccessId { get; set; }

    public Guid GivenBy { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public virtual User GivenByNavigation { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
