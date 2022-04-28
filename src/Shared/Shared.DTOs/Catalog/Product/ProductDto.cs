using Galia.Shared.DTOs.Catalog.Category;

namespace Galia.Shared.DTOs.Catalog;

public class ProductDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Rate { get; set; }
    public string ImagePath { get; set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SubCategoryId { get; set; }

    public CategoryDto Category { get; set; }
    public CategoryDto SubCategory { get; set; }
}
