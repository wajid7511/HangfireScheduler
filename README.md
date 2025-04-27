# Hangfire Minimal Scheduler (Console App)

This project demonstrates a **minimalistic Hangfire setup** inside a **.NET 9 Console App**, focused purely on code and background job scheduling — no APIs, no WebApps.

---

## Features

- 🔹 Schedule background jobs using **Hangfire**
- 🔹 Console App runs Hangfire Server + Dashboard
- 🔹 Supports **CRON expressions**
- 🔹 Manage jobs directly from the **Hangfire Dashboard**

---

## How to Run

1. **Clone** the repository

```bash
git clone https://github.com/wajid7511/HangfireScheduler.git
cd SchedulerApp
```

2. **Install dependencies**

Make sure you have [.NET 9 SDK](https://dotnet.microsoft.com) installed.

```bash
dotnet restore
```

3. **Run the app**

```bash
dotnet run --project SchedulerApp
```

4. **Access Hangfire Dashboard**

Open your browser:

```
http://localhost:5000/hangfire
```

---

## Quick Functionalities

| Feature | URL |
|:---|:---|
| Hangfire Dashboard | `/hangfire` |

---

## Tech Stack

- .NET 9 Console App
- Hangfire Core
- Hangfire.MemoryStorage
- Minimal Hosting APIs

---

## Code Highlights

- **JobHostedService** schedules background jobs.
- **JobStore** manages in-memory job definitions.
- **Startup** configures Hangfire and dashboard.

---

## Example Scheduled Job

A simple background job called **`HelloStudent`** that logs to console every 10 seconds:

```csharp
public class HelloStudent : IJob
{
    public Task ExecuteAsync()
    {
        Console.WriteLine($"[{DateTime.Now}] Hello from Student!");
        return Task.CompletedTask;
    }
}
```

---

## License

Free to use ✨ for demos, learning, and sharing knowledge!

---

## Connect with Me

> Follow my LinkedIn for more .NET tips, minimal projects, and clean code practices!

[LinkedIn Profile](https://www.linkedin.com/in/wajid-nazar-muhammad-106b67103/)

---

Happy Coding! 💻🚀
