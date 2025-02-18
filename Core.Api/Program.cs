using Core.Api.Health;
using FourT.Shared.Utilities.MicroServices.Exceptions;
using FourT.Shared.Utilities.MicroServices.Models;

var builder = WebApplication.CreateBuilder(args);

//get some app settings
var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettings);
builder.Services.AddScoped<AppSettings>();

var isDev = appSettings.GetValue<string>("Environment")?.ToLower() == "development";
var allowedHosts = appSettings.GetSection("AllowedHostNames").Get<string[]>();

var AllowedOrigins = "_allowedOrigins";
builder.Services.Configure<AppSettings>(appSettings);
builder.Services.AddScoped<AppSettings>();

builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase); 
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>("Database");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
if (isDev)
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (isDev)
{    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowedOrigins);
app.UseHttpsRedirection();
app.UseRouting();
app.MapHealthChecks("/health");

app.UseMiddleware<ExceptionHandler>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
