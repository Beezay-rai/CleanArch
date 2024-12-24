using Application;
using Persistence;
using Persistence.Data;
using WebApi.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication()
                .AddPersistence(builder.Configuration);

//builder.Services.AddProblemDetails();


//builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<MyAppDbContext>();
    if (dbcontext != null)
    {
        if(!dbcontext.Database.CanConnect())
        {

        dbcontext.Database.EnsureCreated();
        }
    }
}

app.UseAuthorization();

//app.UseExceptionHandler();
app.MapControllers();
app.Run();
