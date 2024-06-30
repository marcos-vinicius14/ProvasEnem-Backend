

namespace ProvasEnem.Core.Models;

public class ExamModel
{
    public int Id { get; set; }
    public byte[]? ContentPdf { get; set; }
    public string ColorNotebook { get; set; } = string.Empty;
    public DateTime ExamDate { get; set; }

}
