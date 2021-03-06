using Galia.Application.Common.Event;
using Galia.Domain.Catalog.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Galia.Application.Catalog.EventHandlers;

public class ProductUpdatedEventHandler : INotificationHandler<EventNotification<ProductUpdatedEvent>>
{
    private readonly ILogger<ProductUpdatedEventHandler> _logger;

    public ProductUpdatedEventHandler(ILogger<ProductUpdatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(EventNotification<ProductUpdatedEvent> notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", notification.DomainEvent.GetType().Name);
        return Task.CompletedTask;
    }
}
