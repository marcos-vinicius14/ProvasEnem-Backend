using ProvasEnem.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.AddSwagger();
builder.AddDbContext();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.Run();
