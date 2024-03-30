using ALog.Api.Models;
using CustomLogProvider;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<ALogOptions>(
    builder.Configuration.GetSection(ALogOptions.ALog));

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new ALogProvider(builder.Services.BuildServiceProvider().GetService<IOptions<ALogOptions>>())); 

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
