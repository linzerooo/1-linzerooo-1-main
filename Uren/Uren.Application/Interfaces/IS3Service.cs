namespace Finate.Application.Interfaces;

public interface IS3Service
{
    public Task<string?> GetFileUrlAsync(string filename ,CancellationToken cancellationToken = default);
    
    public Task<int> UploadFileAsync(string filename, Stream fileStream, CancellationToken cancellationToken = default);

    public Task<int> UpdateFileAsync(string fileName, Stream fileStream, CancellationToken cancellationToken = default);

    public Task<int> DeleteFileAsync(string fileName, CancellationToken cancellationToken = default);
}