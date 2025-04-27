namespace SchedulerApp.Abstractions;
public interface IJob
{
    Task ExecuteAsync(CancellationToken cancellationToken);
}