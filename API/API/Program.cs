using Interface;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Serilog;
using Serilog.Events;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

//configuracion serilog
string logsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
Directory.CreateDirectory(logsFolder);
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(Path.Combine(logsFolder, "logs.txt"), rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Services.AddDbContext<Marber_BBDDContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

CompositeRoot.DependencyInjection(builder);

builder.Services.AddLogging(loggingBuilder => { loggingBuilder.ClearProviders(); loggingBuilder.AddSerilog(); });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
