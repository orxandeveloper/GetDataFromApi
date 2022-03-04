using Convey.CQRS.Commands;
using GDFA.Application.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDFA.Application.Commands.Handlers
{
    public class PostCommandHandler : ICommandHandler<PostCommand>
    {
        private readonly IRestListenerService _restListenerService;
        private readonly ILogger<PostCommandHandler> _logger;
        public PostCommandHandler(IRestListenerService restListenerService, ILogger<PostCommandHandler> logger)
        {
            _logger = logger;
            _restListenerService = restListenerService;
        }
        public async Task HandleAsync(PostCommand command)
        {
            _logger.LogInformation("PostCommandHandler running at: {time}", DateTimeOffset.Now);

            await _restListenerService.PostAsync();

            _logger.LogInformation("PostCommandHandler stopped at: {time}", DateTimeOffset.Now);
        }
    }
}
