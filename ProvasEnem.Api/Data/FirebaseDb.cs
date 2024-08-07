using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
namespace ProvasEnem.Api.Data;

public class FirebaseDb
{
    private readonly StorageClient _storageClient;
    private readonly string _bucketName;
    public StorageClient storageDb => _storageClient;
    public string bucketName => _bucketName;

    public FirebaseDb(IConfiguration configuration)
    {
        var credentialsPath = configuration["FIREBASE_CREDENTIALS_JSON"];
        var path = configuration["Firebase:BucketName1"];

        if (string.IsNullOrEmpty(credentialsPath) || string.IsNullOrEmpty(path))
            throw new InvalidOperationException("Internal server error");


        _bucketName = path;

        var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromJson(credentialsPath);
        _storageClient = StorageClient.Create(credential);
    }

    public async Task MakeObjectPublic(string objectName)
    {
        var obj = await _storageClient.GetObjectAsync(_bucketName, objectName);

        obj.Acl = obj.Acl ?? new List<ObjectAccessControl>();
        obj.Acl.Add(new ObjectAccessControl
        {
            Entity = "allUsers",
            Role = "READER"
        });

        await _storageClient.UpdateObjectAsync(obj);

    }
}

