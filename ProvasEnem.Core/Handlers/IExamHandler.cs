
using ProvasEnem.Core.Models;
using ProvasEnem.Core.Requests.Exams;
using ProvasEnem.Core.Responses;

namespace ProvasEnem.Core.Handlers;

public interface IExamHandler
{
    Task<IEnumerable<Response<ExamModel>>> ListAllPdf(string prefix);
    Task<Response<Stream>> DownloadPdf(GetExamByYearAndDayRequest request);

}
