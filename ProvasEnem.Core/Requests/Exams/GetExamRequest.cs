using System.ComponentModel.DataAnnotations;
using ProvasEnem.Core.Enums;

namespace ProvasEnem.Core.Requests.Exams;

public class GetExamRequest
{
    [Required]
    [MaxLength(80, ErrorMessage = "Insira no máximo 80 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o ano da prova")]
    [MaxLength(4, ErrorMessage = "Máximo de 4 caracteres")]
    [MinLength(4, ErrorMessage = "Informe um ano válido.")]
    public int Year { get; set; } 

    [Required(ErrorMessage = "Informe um dia.")]
    public DayOfExam Day { get; set; }

}
