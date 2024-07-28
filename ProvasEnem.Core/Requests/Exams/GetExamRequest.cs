using System.ComponentModel.DataAnnotations;

namespace ProvasEnem.Core.Requests.Exams;

public class GetExamByYearRequest
{
    [Required(ErrorMessage = "Informe um ano.")]
    [MaxLength(80, ErrorMessage = "Insira no máximo 80 caracteres.")]
    public string Prefix { get; set; } = string.Empty;

}
