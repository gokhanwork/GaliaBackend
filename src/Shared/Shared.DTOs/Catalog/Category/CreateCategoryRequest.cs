using Galia.Shared.DTOs.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Shared.DTOs.Catalog.Category;

public class CreateCategoryRequest : IMustBeValid
{
    public string Code { get; set; }
    public string Name { get; set; }
    public FileUploadRequest Image { get; set; }
    public Guid ParentCategoryId { get; set; }
}
