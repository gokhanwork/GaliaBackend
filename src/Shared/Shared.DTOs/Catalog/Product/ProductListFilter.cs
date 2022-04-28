using Galia.Shared.DTOs.Filters;

namespace Galia.Shared.DTOs.Catalog;

public class ProductListFilter : PaginationFilter
{
    public Guid? BrandId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
    public Guid? SubCategoryId { get; set; }
}
