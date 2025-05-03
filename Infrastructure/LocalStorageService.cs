using Domain.Interfaces;

namespace Infrastructure;

public class LocalStorageService : IStorageService
{
    private readonly string _basePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

    public LocalStorageService()
    {
        Directory.CreateDirectory(_basePath);
    }

    public async Task<string> SaveFileAsync(Stream stream, string fileName)
    {
        var filePath = Path.Combine(_basePath, fileName);
        using var fileStream = new FileStream(filePath, FileMode.Create);
        await stream.CopyToAsync(fileStream);
        return filePath;
    }

    public Task<Stream> GetFileAsync(string path)
    {
        var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        return Task.FromResult<Stream>(stream);
    }
}
