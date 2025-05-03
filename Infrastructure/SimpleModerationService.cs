using Domain.Entity;
using Domain.Interfaces;

namespace Infrastructure;

public class SimpleModerationService : IModerationService
{
    private readonly List<string> _bannedWords = new() { "spam", "badword" };

    public Task<ModerationResult> ModerateAsync(ContentItem content, CancellationToken ct)
    {
        if (content.Type == "text" && content.PathOrText != null)
        {
            foreach (var word in _bannedWords)
            {
                if (content.PathOrText.Contains(word, StringComparison.OrdinalIgnoreCase))
                    return Task.FromResult(ModerationResult.Rejected($"Содержит запрещенное слово: {word}"));
            }
        }

        return Task.FromResult(ModerationResult.Approved());
    }
}
