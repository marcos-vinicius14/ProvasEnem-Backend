using Google.Cloud.Storage.V1;
using System.IO;

namespace ProvasEnem.Api.Data;

public class FirebaseDb
{
    private readonly StorageClient _storageClient;
    private readonly string _bucketName = APIConfiguration.BucketName;

    public FirebaseDb(IConfiguration configuration)
    {
        var credentialsPath = configuration["Firebase:CredentialsPath"];

        if (string.IsNullOrEmpty(credentialsPath))
            throw new InvalidOperationException("Credencials is empty");

        var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile(credentialsPath);
        _storageClient = StorageClient.Create(credential);
    }

    public StorageClient storage => _storageClient;
    public string bucketName => _bucketName;

    public async Task<String> UploadFile(Stream fileStream, string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new InvalidOperationException("Filename is empty");

        var obj = await _storageClient.UploadObjectAsync(_bucketName, fileName, null, fileStream);

        return $"https://storage.googleapis.com/{_bucketName}/{obj.Name}";
    }

    public async Task<Stream> DownloadFileAsync(string fileName)
    {
        if(string.IsNullOrEmpty(fileName))
            throw new InvalidOperationException($"Unable to download file {fileName}");

        var memoryStream = new MemoryStream();
        await _storageClient.DownloadObjectAsync(_bucketName, fileName, memoryStream);
        memoryStream.Position = 0;

        return memoryStream;
    }

    public async Task<IEnumerable<string>> ListPdfFilesAsync(string prefix)
    {
        var pdfFiles = new List<string>();

        await foreach (var obj in _storageClient.ListObjectsAsync(_bucketName, prefix))
        {
            if (obj.Name.EndsWith(".pdf"))
            {
                pdfFiles.Add(obj.Name);
            }
        }

        return pdfFiles;
    }
}

