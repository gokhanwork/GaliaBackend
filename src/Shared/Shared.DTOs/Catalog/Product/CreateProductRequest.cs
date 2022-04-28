using Galia.Shared.DTOs.Storage;

namespace Galia.Shared.DTOs.Catalog;

public class CreateProductRequest : IMustBeValid
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public Guid UnitId { get; set; }
    public decimal CostPrice { get; set; }
    public decimal Price { get; set; }
    public decimal Rate { get; private set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SubCategoryId { get; set; }
    public decimal Quantity { get; set; }
    public int AlertQuantity { get; set; }
    public FileUploadRequest Image { get; set; }
}
