using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Betting.BackgroundService
{
    public abstract class BackgroundService : IHostedService
    {
        private Task _execTask;
        private readonly CancellationTokenSource _ct = new CancellationTokenSource();
        public Task StartAsync(CancellationToken ct)
        {
            _execTask = ExecuteAsync(_ct.Token);
            if (_execTask.IsCompleted)
            {
                return _execTask;
            }
            return Task.CompletedTask;
        }   


        public virtual async Task StopAsync(CancellationToken ct)
        {
            if (_execTask == null)
                return;
            try
            {
                _ct.Cancel();

            }
            finally
            {

                await Task.WhenAny(_execTask, Task.Delay(Timeout.Infinite, ct));
            }
        }
        protected virtual async Task ExecuteAsync(CancellationToken ct)
        {
            do
            {
                await Process();
                await Task.Delay(5000, ct);
            } while (!ct.IsCancellationRequested);
        }

        protected abstract Task Process();
    }
}
