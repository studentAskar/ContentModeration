using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class UserWindow
{
    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid UserWindowId { get; set; }

    public Guid UserId { get; set; }

    public Guid WindowId { get; set; }

    public Guid CreatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Window Window { get; set; } = null!;
}
