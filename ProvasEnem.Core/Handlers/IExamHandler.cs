
using ProvasEnem.Core.Models;
using ProvasEnem.Core.Requests.Exams;
using ProvasEnem.Core.Responses;

namespace ProvasEnem.Core.Handlers;

public interface IExamHandler
{
    Task<Response<ExamModel>> CreateAsync(CreateExamRequest request);
    Task<Response<ExamModel>> UpdateAsync(UpdateExamRequest request);
    Task<Response<ExamModel>> DeleteAsync(DeleteExamRequest request);
    Task<Response<ExamModel>> GetByYearAsync(GetExamsByYearRequest request);
    Task<Response<List<ExamModel>>> GetAllAsync(GetAllExamsRequest request);
}
