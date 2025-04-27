using SchedulerApp.Abstractions;
namespace SchedulerApp.Jobs;
public class HelloStudent : IJob
{
    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"[{DateTime.Now}] Hello from Student!");
        await Task.CompletedTask;
    }
}
