using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.Hosting;
using SchedulerApp.Core;
using SchedulerApp.Infrastructure;
using SchedulerApp.Jobs;

namespace SchedulerApp.Services;

public class JobHostedService : BackgroundService
{
    private readonly JobStore _store = null!;
    public JobHostedService(JobStore store)
    {
        _store = store ?? throw new ArgumentNullException(nameof(store));
        SeedJobs();
    }

    private void SeedJobs()
    {
        List<JobDefinition> jobs =
        [
            new JobDefinition()
            {
                Name = "HelloWorld",
                JobInstance = new HelloStudent()
            },
            new JobDefinition()
            {
                Name = "HelloTeacher",
                JobInstance = new HelloTeacher()
            },
        ];
        foreach (var job in jobs)
        {
            if (!_store.IsJobExist(job.Name))
            {
                _store.Save(job);
            }
        }
    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var jobs = _store.GetScheduledJobs();

        foreach (var jobDef in jobs)
        {
            RecurringJob.AddOrUpdate(
                jobDef.Name,                                  // Job ID
                () => jobDef.JobInstance.ExecuteAsync(CancellationToken.None), // What to execute
                jobDef.CronExpression                       // Cron Schedule
            );
        }

        return Task.CompletedTask;
    }
}
