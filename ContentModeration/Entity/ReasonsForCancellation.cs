using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class ReasonsForCancellation
{
    public string? Explanation { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ReasonId { get; set; }

    public int RecordId { get; set; }

    public virtual Record Record { get; set; } = null!;
}
