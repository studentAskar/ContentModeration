namespace Domain.Entity;


public class ContentItem
{
public Guid Id { get; set; }
public string Type { get; set; } = default!;

public string PathOrText { get; set; } = default!;

public ContentStatus Status { get; set; } = ContentStatus.Pending;

public string? RejectReason { get; set; }

public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

public DateTime? ModeratedAt { get; set; }
}
