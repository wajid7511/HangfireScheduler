using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using SchedulerApp.Infrastructure;
using SchedulerApp.Services;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add Hangfire services
builder.Services.AddHangfire(config =>
{
    config.UseMemoryStorage();
});
builder.Services.AddHangfireServer();

builder.Services.AddSingleton<JobStore>();
builder.Services.AddHostedService<JobHostedService>();

var app = builder.Build();

// Enable Hangfire Dashboard
app.UseHangfireDashboard("/hangfire");

// Start server
app.RunAsync();

// Open browser automatically (macOS)
try
{
    Process.Start("open", "http://localhost:5000/hangfire");
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to open browser: {ex.Message}");
}

// Keep the app running
await app.WaitForShutdownAsync();
