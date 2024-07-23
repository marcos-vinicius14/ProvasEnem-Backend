
using ProvasEnem.Core.Requests.Exams;
using ProvasEnem.Core.Responses;

namespace ProvasEnem.Core.Handlers;

public interface IExamHandler
{
    Task<IEnumerable<Response<string>>> ListAllPdf(GetExamByYearRequest request);
    Task<Response<Stream>> DownloadPdf(GetExamByYearAndNameRequest request);

}
