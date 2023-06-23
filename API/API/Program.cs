using Interface;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Serilog.Events;
using Serilog;
using Services.IServices;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// todo esto es para serilog - loggeo de errores
string logsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
Directory.CreateDirectory(logsFolder);
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.File(Path.Combine(logsFolder, "logs.txt"), rollingInterval: RollingInterval.Day)
            .CreateLogger();

// conexion a base de datos local
builder.Services.AddDbContext<Marber_BBDDContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

CompositeRoot.DependencyInjection(builder);

builder.Services.AddLogging(loggingBuilder => { loggingBuilder.ClearProviders(); loggingBuilder.AddSerilog(); });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
