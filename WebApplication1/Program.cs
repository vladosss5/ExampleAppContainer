using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string environment = builder.Configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") ?? "Production"; 
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDbContext>(options => options.UseNpgsql(connection));

var app = builder.Build();


if (environment == "Development")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (environment == "Production")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapControllers();

app.Run();