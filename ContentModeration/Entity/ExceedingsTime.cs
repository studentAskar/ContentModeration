using Domain.Entity;
using System;
using System.Collections.Generic;

namespace DomainDomain.Entity;

public partial class ExceedingsTime
{
    public int TimeForExcommunication { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? CanceledOn { get; set; }

    public Guid ExceedingsTimeId { get; set; }

    public Guid WindowId { get; set; }

    public virtual Window Window { get; set; } = null!;
}
