
using Google.Cloud.Storage.V1;
using ProvasEnem.Api.Data;
using ProvasEnem.Core.Handlers;
using ProvasEnem.Core.Models;
using ProvasEnem.Core.Requests.Exams;
using ProvasEnem.Core.Responses;
using System.IO;

namespace ProvasEnem.Api.Handlers;

public class ExamHandler : IExamHandler
{
    private readonly FirebaseDb _firebaseDb;

    public ExamHandler(FirebaseDb firebaseDb)
    {
        _firebaseDb = firebaseDb;
    }

    public async Task<IEnumerable<Response<string>>> ListAllPdf(GetExamByYearRequest request)
    {
        if (string.IsNullOrEmpty(request.Prefix))
            throw new InvalidOperationException("Prefixo vazio");

        var pdfFiles = new List<string>();


        await foreach (var pdf in _firebaseDb.storageDb.ListObjectsAsync(_firebaseDb.bucketName, request.Prefix))
        {
            if(pdf.Name.EndsWith(".pdf"))
                pdfFiles.Add(pdf.Name);
        }

        return pdfFiles.Select(file => new Response<string>(file, 200, "Operaçao realizada com sucesso"));

    }

    public async Task<Response<Stream>> DownloadPdf(GetExamByYearAndNameRequest request)
    {
        if(string.IsNullOrEmpty(request.FileName))
            throw new InvalidOperationException("Não foi possível realizar o downlod.");
            
         var filePath = $"{_firebaseDb.bucketName}/{request.DayOfExam}/{request.FileName}";

        var memoryStream = new MemoryStream();

        await _firebaseDb.storageDb.DownloadObjectAsync(_firebaseDb.bucketName, filePath, memoryStream);
        memoryStream.Position = 0;

        return new Response<Stream>(memoryStream, 200, "Operação realizada com sucesso");


    }
}
