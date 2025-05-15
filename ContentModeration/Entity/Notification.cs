using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Notification
{
    public string NameRu { get; set; } = null!;

    public string NameKk { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? ContentRu { get; set; }

    public string? ContentKk { get; set; }

    public string? ContentEn { get; set; }

    public int NotificationTypeId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid NotificationId { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid? QueueTypeId { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual NotificationType NotificationType { get; set; } = null!;

    public virtual QueueType? QueueType { get; set; }
}
