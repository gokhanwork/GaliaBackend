using Galia.Application.Common.Event;
using Galia.Domain.Catalog.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Galia.Application.Catalog.EventHandlers;

public class ProductCreatedEventHandler : INotificationHandler<EventNotification<ProductCreatedEvent>>
{
    private readonly ILogger<ProductCreatedEventHandler> _logger;

    public ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(EventNotification<ProductCreatedEvent> notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", notification.DomainEvent.GetType().Name);
        return Task.CompletedTask;
    }
}
