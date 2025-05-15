namespace Infrastructure;



public class SignalROptions
{
    public static string SectionName = nameof(SignalROptions);
    public string BaseUrl { get; set; } = string.Empty;
    public string HubPath { get; set; } = string.Empty;
}