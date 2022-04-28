using Galia.Domain.Common.Contracts;
using Galia.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Domain.Catalog;

public class Category : AuditableEntity, IMustHaveTenant
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public string Tenant { get; set; }
    public virtual Category ParentCategory { get; set; }
    public virtual ICollection<Category> ChildCategories { get; set; }

    public Category(string code, string name, string image, Guid parentCategoryId)
    {
        Code = code;
        Name = name;
        Image = image;
        ParentCategoryId = parentCategoryId;
    }

    public Category()
    {
    }

}
