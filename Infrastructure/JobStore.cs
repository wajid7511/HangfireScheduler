using LiteDB;
using SchedulerApp.Core;

namespace SchedulerApp.Infrastructure;
public class JobStore
{
    private readonly LiteDatabase _db;
    private readonly ILiteCollection<JobDefinition> _jobs;

    public JobStore(string databasePath = "jobs.db")
    {
        _db = new LiteDatabase(databasePath);
        //_db.GetCollection<JobDefinition>("jobs").DeleteAll();
        _jobs = _db.GetCollection<JobDefinition>("jobs");
    }

    public void Save(JobDefinition job) => _jobs.Upsert(job);
    public IEnumerable<JobDefinition> GetScheduledJobs() => _jobs.FindAll();
    public bool IsJobExist(string name) => _jobs.Count(x => x.Name == name) > 0;
}
