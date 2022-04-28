using Galia.Domain.Common.Contracts;

namespace Galia.Domain.Catalog.Events;

public class ProductUpdatedEvent : DomainEvent
{
    public ProductUpdatedEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; }
}
