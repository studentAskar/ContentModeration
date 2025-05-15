using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class RecordStatus
{
    public int RecordStatusId { get; set; }

    public string NameRu { get; set; } = null!;

    public string NameKk { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? DescriptionRu { get; set; }

    public string? DescriptionKk { get; set; }

    public string? DescriptionEn { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<QueueItem> QueueItems { get; set; } = new List<QueueItem>();
}
