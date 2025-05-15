using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class RoleResourceAction
{
    public int ResourceId { get; set; }

    public int ActionId { get; set; }

    public string? DescriptionRu { get; set; }

    public string? DescriptionKk { get; set; }

    public string? DescriptionEn { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid RoleResourceActionId { get; set; }

    public Guid RoleId { get; set; }

    public Guid CreatedBy { get; set; }

    public virtual Action Action { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Resource Resource { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
