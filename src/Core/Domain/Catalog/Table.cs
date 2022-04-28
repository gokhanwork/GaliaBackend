using Galia.Domain.Common.Contracts;
using Galia.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Domain.Catalog;

public class Table : AuditableEntity, IMustHaveTenant
{
    public string TableName { get; set; }
    public bool TableStatus { get; set; }
    public string Tenant { get; set; }
    public Table(string tableName, bool tableStatus)
    {
        TableName = tableName;
        TableStatus = tableStatus;
    }

    public Table()
    {
    }
}
