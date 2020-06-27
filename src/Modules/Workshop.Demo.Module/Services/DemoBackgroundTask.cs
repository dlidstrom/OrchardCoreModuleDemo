using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrchardCore.BackgroundTasks;

namespace Workshop.Demo.Module.Services
{
    [BackgroundTask(Schedule = "*/1 * * * *", Description = "Demo background task.")]
    public class MyFirstBackgroundTask : IBackgroundTask
    {
        private readonly ILogger<MyFirstBackgroundTask> L;

        public MyFirstBackgroundTask(ILogger<MyFirstBackgroundTask> logger)
        {
            this.L = logger;
        }

        public Task DoWorkAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            L.LogError("Error!");
            return Task.CompletedTask;
        }
    }
}
