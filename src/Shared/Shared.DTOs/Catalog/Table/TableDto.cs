using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Shared.DTOs.Catalog.Table;

public class TableDto : IDto
{
    public Guid Id { get; set; }
    public string TableName { get; set; }
    public bool TableStatus { get; set; }
}
