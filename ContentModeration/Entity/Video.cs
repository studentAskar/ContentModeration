namespace Domain.Entity;

public class Video
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public ContentStatus Status { get; set; } 
    public DateTime UploadedAt { get; set; }
}
