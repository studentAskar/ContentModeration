using DomainDomain.Entity;
using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Window
{
    public int WindowStatusId { get; set; }

    public int WindowNumber { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid WindowId { get; set; }

    public Guid CreatedBy { get; set; }

    public string? NameRu { get; set; }

    public string? NameKk { get; set; }

    public string? NameEn { get; set; }

    public Guid? QueueTypeId { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<ExceedingsTime> ExceedingsTimes { get; set; } = new List<ExceedingsTime>();

    public virtual QueueType? QueueType { get; set; }

    public virtual ICollection<UserWindow> UserWindows { get; set; } = new List<UserWindow>();

    public virtual WindowStatus WindowStatus { get; set; } = null!;
}
