using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class QueueItem
{
    public DateTime CreatedOn { get; set; }

    public Guid QueueItemId { get; set; }

    public Guid ManagerId { get; set; }

    public int StatusId { get; set; }

    public int RecordId { get; set; }

    public virtual User Manager { get; set; } = null!;

    public virtual Record Record { get; set; } = null!;

    public virtual RecordStatus Status { get; set; } = null!;
}
