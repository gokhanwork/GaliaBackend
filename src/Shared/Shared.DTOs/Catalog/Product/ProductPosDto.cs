using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Shared.DTOs.Catalog.Product;

public class ProductPosDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SubCategoryId { get; set; }
}
