using SchedulerApp.Abstractions;
namespace SchedulerApp.Jobs;
public class HelloTeacher : IJob
{
    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"[{DateTime.Now}] Hello from Teacher!");
        await Task.Delay(500, cancellationToken);
    }
}
