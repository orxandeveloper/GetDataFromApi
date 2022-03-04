using Convey.CQRS.Commands;
using GDFA.Application.Commands;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetDataFromApi
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICommandDispatcher _commandDispatcher;
        private int duration = 1000;

        public Worker(ILogger<Worker> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            bool isHasRan = false;

            do
            {
                await Task.Delay(duration, stoppingToken);

                try
                {
                    await _commandDispatcher.SendAsync(new PostCommand { });
                    isHasRan = true;

                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                }

            } while (!stoppingToken.IsCancellationRequested && !isHasRan);


            // _logger.LogInformation("Worker stopped at: {time}", DateTimeOffset.Now);
        }
    }
}
