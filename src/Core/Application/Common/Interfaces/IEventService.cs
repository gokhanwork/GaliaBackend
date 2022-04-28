using Galia.Domain.Common.Contracts;

namespace Galia.Application.Common.Interfaces;

public interface IEventService : ITransientService
{
    Task PublishAsync(DomainEvent domainEvent);
}
