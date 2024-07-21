using Microsoft.Extensions.DependencyInjection.Extensions;
using ProvasEnem.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


builder.AddSwagger();
builder.AddDbContext();

builder.Services.AddSingleton();


app.UseSwaggerApi();

app.MapGet("/", () => "Hello World!");

app.Run();