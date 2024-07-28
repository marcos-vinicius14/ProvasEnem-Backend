using Microsoft.Extensions.DependencyInjection.Extensions;
using ProvasEnem.Api.Data;
using ProvasEnem.Api.Handlers;
using ProvasEnem.Core.Handlers;

namespace ProvasEnem.Api.Extensions;

public static class DependenciesExtensions
{
    public static void AddSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<FirebaseDb>();
    }

    public static void AddTransient(this IServiceCollection services)
    {
        services.TryAddTransient<IExamHandler, ExamHandler>();
    }
}
