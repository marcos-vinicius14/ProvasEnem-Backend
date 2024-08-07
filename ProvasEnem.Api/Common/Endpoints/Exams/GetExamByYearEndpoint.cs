using Microsoft.AspNetCore.Mvc;
using ProvasEnem.Api.Common.Api;
using ProvasEnem.Core.Handlers;
using ProvasEnem.Core.Requests.Exams;

namespace ProvasEnem.Api.Common.Endpoints.Exams;

public class GetExamByYearEndpoint : IEndpoint
{
    private readonly IExamHandler _handler;

    public GetExamByYearEndpoint(IExamHandler handler)
       =>  _handler = handler;
    

    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithDisplayName("Exams: Get")
            .WithSummary("Lista todas as provas, filtradas por ano, do banco de dados")
            .WithOrder(1);

    private static async Task<IResult> HandleAsync(
       [FromServices] IExamHandler handler,
       [FromQuery] string prefix)
    {
        if (string.IsNullOrEmpty(prefix))
            return TypedResults.BadRequest();

        var result = await handler.ListAllPdf(prefix);

        return TypedResults.Ok(result);
    }

}
