using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Shared.DTOs.Catalog.Category;

public class CategoryDto : IDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public Guid ParentCategoryId { get; set; }
    public string ParentCategoryName { get; set; }

}
