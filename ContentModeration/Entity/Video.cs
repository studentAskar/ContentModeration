using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Video
{
    public int Id { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public int Status { get; set; }

    public DateTime UploadedAt { get; set; }
}
