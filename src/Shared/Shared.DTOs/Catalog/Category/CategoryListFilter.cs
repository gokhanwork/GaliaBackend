using Galia.Shared.DTOs.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Shared.DTOs.Catalog.Category;

public class CategoryListFilter : PaginationFilter
{
    public Guid? ParentCategoryId { get; set; }

}
