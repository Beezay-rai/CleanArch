using Application;
using Persistence;
using WebApi.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication()
                .AddPersistence(builder.Configuration);

builder.Services.AddProblemDetails();


builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();



app.UseAuthorization();

app.UseExceptionHandler();
app.MapControllers();
app.Run();
