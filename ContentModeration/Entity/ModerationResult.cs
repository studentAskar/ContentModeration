namespace Domain.Entity;

public class ModerationResult
{
    public bool IsApproved { get; init; }
    public string? Reason { get; init; }

    public static ModerationResult Approved() => new() { IsApproved = true };
    public static ModerationResult Rejected(string reason) => new() { IsApproved = false, Reason = reason };
}
