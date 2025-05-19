using Finate.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace Finate.Services.S3Service;

public class S3Service(IConfiguration configuration, IMinioClient minio, ILogger<S3Service> logger) : IS3Service
{
    private readonly string _bucketName = configuration["S3:BucketName"]!;
    
    public async Task<string?> GetFileUrlAsync(string filename, CancellationToken cancellationToken = default)
    {
        try
        {
            var presignedGetObjectArgs = new PresignedGetObjectArgs().WithBucket(_bucketName).WithObject(filename).WithExpiry(604000);
            var objectStat = await minio.PresignedGetObjectAsync(presignedGetObjectArgs).ConfigureAwait(false);
            return objectStat;
        }
        catch (MinioException e)
        {
            logger.Log(LogLevel.Error, $"Cannot get file url: {filename} \nError: {e.Message}");
        }

        return null;
    }

    public async Task<int> UploadFileAsync(string filename, Stream fileStream, CancellationToken cancellationToken = default)
    {
        try
        {
            var beArgs = new BucketExistsArgs()
                .WithBucket(_bucketName);
            
            var found = await minio.BucketExistsAsync(beArgs, cancellationToken).ConfigureAwait(false);
            
            if (!found)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket(_bucketName);
                await minio.MakeBucketAsync(mbArgs, cancellationToken).ConfigureAwait(false);
            }
            // Upload a file to bucket.
            var putObjectArgs = new PutObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(filename)
                .WithStreamData(fileStream)
                .WithObjectSize(fileStream.Length); 
            
            await minio.PutObjectAsync(putObjectArgs, cancellationToken).ConfigureAwait(false);
            
            logger.Log(LogLevel.Information, $"Successfully uploaded {filename}" );
            return 1;
        }
        catch (MinioException e)
        {
            logger.Log(LogLevel.Error, $"File Upload Error: {filename}\nError: {e.Message}");
            return 0;
        }   
    }

    public async Task<int> UpdateFileAsync(string fileName, Stream fileStream, CancellationToken cancellationToken = default)
    {
        var deleteFileResult = await DeleteFileAsync(fileName, cancellationToken);

        if (deleteFileResult == 0)
            return 0;

        var uploadFileResult = await UploadFileAsync(fileName, fileStream, cancellationToken);

        return uploadFileResult == 0 ? 0 : 1;
    }

    public async Task<int> DeleteFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var removeObjectArgs = new RemoveObjectArgs().WithObject(fileName).WithBucket(_bucketName);

        if (removeObjectArgs == null)
            return 0;

        try
        {
            await minio.RemoveObjectAsync(removeObjectArgs, cancellationToken).ConfigureAwait(false);
        }
        catch (MinioException e)
        {
            logger.Log(LogLevel.Error, $"Cannot delete file: {fileName} \nError: {e.Message}");
        }

        return 1;
    }
}