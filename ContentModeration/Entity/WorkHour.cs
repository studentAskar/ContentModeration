using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class WorkHour
{
    public int DayOfWeek { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public Guid WorkHourId { get; set; }

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
