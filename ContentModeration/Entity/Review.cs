using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Review
{
    public int Rating { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ReviewId { get; set; }

    public int RecordId { get; set; }

    public virtual Record Record { get; set; } = null!;
}
