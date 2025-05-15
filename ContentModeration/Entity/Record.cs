using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Record
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Surname { get; set; }

    public string Iin { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public bool IsCreatedByEmployee { get; set; }

    public int TicketNumber { get; set; }

    public Guid ServiceId { get; set; }

    public Guid? CreatedBy { get; set; }

    public int RecordId { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<QueueItem> QueueItems { get; set; } = new List<QueueItem>();

    public virtual ICollection<ReasonsForCancellation> ReasonsForCancellations { get; set; } = new List<ReasonsForCancellation>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Service Service { get; set; } = null!;
}
