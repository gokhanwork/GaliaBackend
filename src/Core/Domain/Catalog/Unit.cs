using Galia.Domain.Common.Contracts;
using Galia.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Domain.Catalog;

public class Unit : AuditableEntity, IMustHaveTenant
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Tenant { get; set; }

    public Unit(string name, string code)
    {
        Name = name;
        Code = code;
    }

    public Unit()
    {
    }
}
