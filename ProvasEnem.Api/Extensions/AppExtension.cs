namespace ProvasEnem.Api.Extensions;

public static class AppExtension
{
    public static void UseSwaggerApi(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}