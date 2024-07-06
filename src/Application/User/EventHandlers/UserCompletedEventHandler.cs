using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sample.Test.Domain.Events;

namespace Sample.Test.Application.User.EventHandlers
{
    public class UserCompletedEventHandler : INotificationHandler<UserCompletedEvent>
    {
    private readonly ILogger<UserCompletedEventHandler> _logger;

    public UserCompletedEventHandler(ILogger<UserCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sample.Test Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
    }
}