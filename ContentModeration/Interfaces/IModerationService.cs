using Domain.Entity;

namespace Domain.Interfaces;

public interface IModerationService
{
    Task<ModerationResult> ModerateAsync(ContentItem content, CancellationToken ct);
}
