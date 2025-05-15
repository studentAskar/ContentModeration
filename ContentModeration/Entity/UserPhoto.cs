using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class UserPhoto
{
    public string PhotoUrl { get; set; } = null!;

    public Guid UserPhotoId { get; set; }

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
