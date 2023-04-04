using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Betting.BackgroundService
{
    public abstract class Processor : BackgroundService
    {
        private IServiceScopeFactory _serviceScopedFactory;

        public Processor(IServiceScopeFactory serviceScopeFactory) : base()
        {
            _serviceScopedFactory = serviceScopeFactory;
        }
        protected override async Task Process()
        {
            using (var scope = _serviceScopedFactory.CreateScope())
                await ProcessInScope(scope.ServiceProvider);
        }
        public abstract Task ProcessInScope(IServiceProvider serviceProvider);
    }
}   
