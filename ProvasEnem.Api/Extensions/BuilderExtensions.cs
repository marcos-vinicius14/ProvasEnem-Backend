

namespace ProvasEnem.Api.Extensions;

public static class BuilderExtensions
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });
    }

}