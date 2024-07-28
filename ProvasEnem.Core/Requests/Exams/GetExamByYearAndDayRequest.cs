
using ProvasEnem.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProvasEnem.Core.Requests.Exams;

public class GetExamByYearAndDayRequest
{
    [Required(ErrorMessage = "Informe o nome do arquivo")]
    [MaxLength(30)]
    public string FileName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Informe um ano.")]
    [Range(2010, 2024, ErrorMessage = "Informe um ano entre 2010 e 2024")]
    public int YearExam { get; set; }

    [Required(ErrorMessage = "Informe o dia da prova.")]
    public DayOfExam DayOfExam { get; set; }
}
