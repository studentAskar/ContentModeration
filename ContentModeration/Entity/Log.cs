using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Log
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; }

    public string Level { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? Exception { get; set; }

    public string? Properties { get; set; }
}
