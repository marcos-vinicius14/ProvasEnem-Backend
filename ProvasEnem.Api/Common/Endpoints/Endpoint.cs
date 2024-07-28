using ProvasEnem.Api.Common.Api;
using ProvasEnem.Api.Common.Endpoints.Exams;

namespace ProvasEnem.Api.Common.Endpoints;

public static class Endpoint 
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("");

        endpoints.MapGroup("v1/provas")
            .WithTags("Provas")
            .MapEndpoint<GetExamByYearEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
         where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }

}
