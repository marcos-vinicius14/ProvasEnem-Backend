using ProvasEnem.Api.Common.Endpoints;
using ProvasEnem.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddSingleton();
builder.Services.AddTransient();
builder.Services.AddSwagger();

var app = builder.Build();

app.UseSwaggerApi();
app.MapGet("/", ()  => new { Message = "Ok"});
app.MapEndpoints();


app.Run();
