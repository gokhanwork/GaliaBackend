using Galia.Domain.Common.Contracts;

namespace Galia.Domain.Catalog.Events;

public class ProductDeletedEvent : DomainEvent
{
    public ProductDeletedEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; }
}
