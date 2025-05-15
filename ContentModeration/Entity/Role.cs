using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Role
{
    public string NameRu { get; set; } = null!;

    public string NameKk { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? DescriptionRu { get; set; }

    public string? DescriptionKk { get; set; }

    public string? DescriptionEn { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid RoleId { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid? QueueTypeId { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual QueueType? QueueType { get; set; }

    public virtual ICollection<RoleAccess> RoleAccesses { get; set; } = new List<RoleAccess>();

    public virtual ICollection<RoleResourceAction> RoleResourceActions { get; set; } = new List<RoleResourceAction>();
}
