using Microsoft.Extensions.DependencyInjection;
using NCrontab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
        
namespace Betting.BackgroundService
{
    public class ScheduleProcessor : Processor
    {
        private CrontabSchedule _schedule;
        private DateTime _nextRun;

        protected virtual string Schedule { get; }
        public ScheduleProcessor(IServiceScopeFactory serviceScopeFactory): base(serviceScopeFactory)
        {
            _schedule = CrontabSchedule.Parse(Schedule);
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }


        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            do
            {
                var currentDateTime = DateTime.Now;
                if (currentDateTime > _nextRun)
                {
                    await Process();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
                await Task.Delay(50000, ct);

            } while (!ct.IsCancellationRequested);
        }

       
    }
}

