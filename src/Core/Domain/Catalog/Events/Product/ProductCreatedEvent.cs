using Galia.Domain.Common.Contracts;
using Galia.Domain.Catalog;

namespace Galia.Domain.Catalog.Events;

public class ProductCreatedEvent : DomainEvent
{
    public ProductCreatedEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; }
}
