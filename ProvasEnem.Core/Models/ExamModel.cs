
using Google.Cloud.Firestore;

namespace ProvasEnem.Core.Models;

[FirestoreData]
public class ExamModel
{
    [FirestoreProperty]
    public string FileName { get;  set; } = string.Empty;

    [FirestoreProperty]
    public string DownloadUrl { get; set; } = string.Empty;

    [FirestoreProperty]
    public string Prefix { get;  set; } = string.Empty;

}
