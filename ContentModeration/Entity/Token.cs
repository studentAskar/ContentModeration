using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Token
{
    public Guid AccessToken { get; set; }

    public Guid UserId { get; set; }

    public bool IsUsed { get; set; }

    public virtual User User { get; set; } = null!;
}
