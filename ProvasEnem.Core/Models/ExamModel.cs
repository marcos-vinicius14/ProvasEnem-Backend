
using Google.Cloud.Firestore;
using ProvasEnem.Core.Enums;

namespace ProvasEnem.Core.Models;

[FirestoreData]
public class ExamModel
{
    [FirestoreProperty]
    public string Name { get;  set; } = string.Empty;

    [FirestoreProperty]
    public string Prefix { get;  set; } = string.Empty;

    [FirestoreProperty]
    public string ExamUrl { get; set; } = string.Empty;

}
