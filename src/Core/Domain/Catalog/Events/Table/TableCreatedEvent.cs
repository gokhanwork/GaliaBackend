using Galia.Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Domain.Catalog.Events;

public class TableCreatedEvent : DomainEvent
{
    public TableCreatedEvent(Table table)
    {
        Table = table;
    }

    public Table Table { get; }
}
