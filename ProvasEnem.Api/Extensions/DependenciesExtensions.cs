using Microsoft.Extensions.DependencyInjection.Extensions;
using ProvasEnem.Api.Data;

namespace ProvasEnem.Api.Extensions;

public static class DependenciesExtensions
{
    public static void AddSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<FirebaseDb>();
    }
}
