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

    public StorageClient storageDb => _storageClient;
    public string bucketName => _bucketName;


  
}

