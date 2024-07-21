
using Google.Cloud.Firestore;
using ProvasEnem.Core.Enums;

namespace ProvasEnem.Core.Models;

[FirestoreData]
public class ExamModel
{
    [FirestoreDocumentId]
    public string ExamId { get; set; } = string.Empty;

    [FirestoreProperty]
    public string ExamPdfUrl { get; set; } = string.Empty;

    [FirestoreProperty]
    public string? ColorNotebook { get; set; }

    [FirestoreProperty]
    public int YearExam { get; set; }

    [FirestoreProperty]
    public DayOfExam DayExam { get; set; }
}
