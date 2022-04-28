using Galia.Domain.Common.Contracts;
using MediatR;

namespace Galia.Application.Common.Event;

public class EventNotification<T> : INotification
where T : DomainEvent
{
    public EventNotification(T domainEvent)
    {
        DomainEvent = domainEvent;
    }

    public T DomainEvent { get; }
}
