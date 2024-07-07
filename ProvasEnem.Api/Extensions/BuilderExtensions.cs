using Microsoft.EntityFrameworkCore;
using ProvasEnem.Api.Data;

namespace ProvasEnem.Api.Extensions;

public static class BuilderExtensions
{
    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });
    }

    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        var connectionString = builder
            .Configuration
            .GetConnectionString("DefaultConnection") ?? string.Empty;

        builder.Services.AddDbContext<AppDbContext>(x => { x.UseSqlServer(connectionString); });
    }
}