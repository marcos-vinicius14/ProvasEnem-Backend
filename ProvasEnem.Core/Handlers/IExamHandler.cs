
using ProvasEnem.Core.Models;
using ProvasEnem.Core.Responses;

namespace ProvasEnem.Core.Handlers;

public interface IExamHandler
{
    Task<IEnumerable<Response<ExamResponse>>> ListAllPdf(string prefix);

}
