using Serilog;
using uCondo.Galdino.BootStraper.Configurations.Auth;
using uCondo.Galdino.BootStraper.Configurations.AutoMapper;
using uCondo.Galdino.BootStraper.Configurations.Cors;
using uCondo.Galdino.BootStraper.Configurations.Injections;
using uCondo.Galdino.BootStraper.Configurations.Logger;
using uCondo.Galdino.BootStraper.Configurations.Swagger;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var provider = services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
services.AddAutoMapperConfiguration();
services.AddAutoMapperModelViewConfiguration();

AuthConfiguration.Register(services, configuration);
LoggerBuilder.ConfigureLogging();

services.AddProtectedControllers();
services.AddServices(configuration);
services.AddCors();
services.AddSwagger();
services.AddDatabaseConfiguration(configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCorsConfig();
app.UseAuthorization();
app.UseAuthentication();
app.UseRouting();
app.UseSwaggerConfig();
app.UseEndpointsConfig();
app.UseHttpsRedirection();

app.Run();