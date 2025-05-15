using Domain;
using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Action
{
    public int ActionId { get; set; }

    public string Name { get; set; } = null!;

    public string? DescriptionRu { get; set; }

    public string? DescriptionKk { get; set; }

    public string? DescriptionEn { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<RoleResourceAction> RoleResourceActions { get; set; } = new List<RoleResourceAction>();
}
