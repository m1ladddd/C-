using TemperatureMonitoring.Models;
using TemperatureMonitoring.Services;
using TemperatureMonitoring.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on HTTPS for localhost:8888
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(8888, listenOptions =>
    {
        listenOptions.UseHttps(); // Enforce HTTPS on port 8888
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<MockSensorService>();
builder.Services.AddSignalR(); // Add SignalR for WebSocket connections

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS to allow access from the frontend
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://climate.dops.tech") // Replace with your frontend URL
                  .AllowCredentials()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(); // Apply CORS policy
app.UseAuthorization();

app.MapControllers();
app.MapHub<TemperatureHub>("/hubs/temperature");

app.Run();
