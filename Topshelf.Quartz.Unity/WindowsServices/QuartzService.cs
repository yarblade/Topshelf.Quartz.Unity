using System;

using Common.Logging;

using Quartz;

using Topshelf.Unity.WindowsServices;

namespace Topshelf.Quartz.Unity.WindowsServices
{
    internal class QuartzService : IWindowsService
    {
        private readonly ILog _log = LogManager.GetLogger<QuartzService>();
        private readonly IScheduler _scheduler;

        public QuartzService(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public void Start()
        {
            try
            {
                _scheduler.Start();
            }
            catch (Exception ex)
            {
                _log.FatalFormat("Scheduler start failed: {0}.", ex, ex.Message);
                throw;
            }

            _log.Info("Scheduler started successfully.");
        }

        public void Stop()
        {
            try
            {
                _scheduler.Shutdown(true);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Scheduler start failed: {0}.", ex, ex.Message);
                throw;
            }

            _log.Info("Scheduler shutdown complete.");
        }
    }
}
