namespace Domain.Interfaces;

public interface IStorageService
{
    Task<string> SaveFileAsync(Stream stream, string fileName);
    Task<Stream> GetFileAsync(string path);
}
