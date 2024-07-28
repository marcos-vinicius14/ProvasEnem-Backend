using ProvasEnem.Api.Data;
using ProvasEnem.Core.Handlers;
using ProvasEnem.Core.Models;
using ProvasEnem.Core.Requests.Exams;
using ProvasEnem.Core.Responses;

namespace ProvasEnem.Api.Handlers;

public class ExamHandler : IExamHandler
{
    private readonly FirebaseDb _firebaseDb;

    public ExamHandler(FirebaseDb firebaseDb)
    {
        _firebaseDb = firebaseDb;
    }

    public async Task<IEnumerable<Response<ExamModel>>> ListAllPdf(string prefix)
    {
        if (string.IsNullOrEmpty(prefix))
            throw new InvalidOperationException("Prefixo vazio");

        //var pdfFiles = new List<string>();
        var listPdfs = new List<Response<ExamModel>>();


        await foreach (var pdf in _firebaseDb.storageDb.ListObjectsAsync(_firebaseDb.bucketName, prefix))
        {
            if(pdf.Name.EndsWith(".pdf"))
            {
                await _firebaseDb.MakeObjectPublic(pdf.Name);
                var model = new ExamModel
                {
                    Name = pdf.Name,
                    ExamUrl = pdf.MediaLink,
                    Prefix = prefix,
                };

                listPdfs.Add(new Response<ExamModel>(model, 200, "Ok"));
            }
        }

        return listPdfs;


    }

    public async Task<Response<Stream>> DownloadPdf(GetExamByYearAndDayRequest request)
    {
        if(string.IsNullOrEmpty(request.FileName))
            throw new InvalidOperationException("Não foi possível realizar o downlod.");
            
         var filePath = $"{_firebaseDb.bucketName}/{request.DayOfExam}/{request.FileName}";

        var memoryStream = new MemoryStream();

        await _firebaseDb.storageDb.DownloadObjectAsync(_firebaseDb.bucketName, filePath, memoryStream);
        memoryStream.Position = 0;

        return new Response<Stream>(memoryStream, 200, "Operação realizada com sucesso.");


    }
}
