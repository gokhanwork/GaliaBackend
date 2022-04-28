using Galia.Domain.Common;
using Galia.Domain.Common.Contracts;
using Galia.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Galia.Domain.Catalog;

public class Product : AuditableEntity, IMustHaveTenant
{
    public string Name { get;  set; }
    public string Description { get;  set; }
    public string Code { get; set; }
    public Guid UnitId { get; set; }
    public decimal CostPrice { get; set; }
    public decimal Price { get; set; }
    public decimal Rate { get;  set; }
    public string Tenant { get; set; }
    public string ImagePath { get; set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
    public decimal Quantity { get; set; }
    public decimal AlertQuantity { get; set; }
    public virtual Brand Brand { get; set; }
    public virtual Category Category { get; set; }
    public virtual Category SubCategory { get; set; }
    public virtual Unit Unit { get; set; }
    public Product()
    {
    }

    public Product(string name, string description, string code, Guid unitId, decimal costPrice, decimal price, decimal rate, string ýmagePath, Guid brandId, Guid categoryId, Guid subCategoryId, decimal quantity, decimal alertQuantity)
    {
        Name = name;
        Description = description;
        Code = code;
        UnitId = unitId;
        CostPrice = costPrice;
        Price = price;
        Rate = rate;
        ImagePath = ýmagePath;
        BrandId = brandId;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        Quantity = quantity;
        AlertQuantity = alertQuantity;
    }

    public Product Update(string name, string description, decimal rate, in Guid brandId, string imagePath)
    {
        if (name != null && !Name.NullToString().Equals(name)) Name = name;
        if (description != null && !Description.NullToString().Equals(description)) Description = description;
        if (Rate != rate) Rate = rate;
        if (brandId != Guid.Empty && !BrandId.NullToString().Equals(brandId)) BrandId = brandId;
        if (imagePath != null && !ImagePath.NullToString().Equals(imagePath)) ImagePath = imagePath;
        return this;
    }
}
