using ProvasEnem.Api.Data;
using ProvasEnem.Core.Handlers;
using ProvasEnem.Core.Responses;

namespace ProvasEnem.Api.Handlers;

public class ExamHandler : IExamHandler
{
    private readonly FirebaseDb _firebaseDb;

    public ExamHandler(FirebaseDb firebaseDb)
    {
        _firebaseDb = firebaseDb;
    }

    public async Task<IEnumerable<Response<ExamResponse>>> ListAllPdf(string prefix)
    {
        //provas/2020/dia-01
        if (string.IsNullOrEmpty(prefix))
            throw new InvalidOperationException("Falha interna.");

        //var pdfFiles = new List<string>();
        var listPdfs = new List<Response<ExamResponse>>();


        await foreach (var pdf in _firebaseDb.storageDb.ListObjectsAsync(_firebaseDb.bucketName, prefix))
        {
            if(pdf.Name.EndsWith(".pdf"))
            {
                await _firebaseDb.MakeObjectPublic(pdf.Name);
                var model = new ExamResponse
                {
                    FileName = pdf.Name,
                    DownloadUrl = pdf.MediaLink,
                    Prefix = prefix,
                };

                listPdfs.Add(new Response<ExamResponse>(model, 200, "Ok"));
            }
        }

        return listPdfs;


    }

}
