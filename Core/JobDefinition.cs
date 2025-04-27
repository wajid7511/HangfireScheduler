using NCrontab;
using SchedulerApp.Abstractions;

namespace SchedulerApp.Core;

public class JobDefinition
{
    public string Name { get; set; } = string.Empty;
    public IJob JobInstance { get; set; } = default!;
    public string CronExpression { get; set; } = "* * * * *"; // Default: every minute 
}
