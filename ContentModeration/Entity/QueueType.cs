using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class QueueType
{
    public string NameRu { get; set; } = null!;

    public string NameKk { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? DescriptionRu { get; set; }

    public string? DescriptionKk { get; set; }

    public string? DescriptionEn { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid QueueTypeId { get; set; }

    public Guid CreatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Window> Windows { get; set; } = new List<Window>();
}
