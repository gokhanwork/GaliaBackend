using Galia.Application.Common.Interfaces;
using Galia.Application.Wrapper;
using Galia.Shared.DTOs.Catalog.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Application.Catalog.Interfaces;

public interface ICategoryService : ITransientService
{
    Task<PaginatedResult<CategoryDto>> SearchAsync(CategoryListFilter filt);
    Task<Result<Guid>> CreateCategoryAsync(CreateCategoryRequest category);
    Task<Result<Guid>> UpdateCategoryAsync();
    Task<Result<Guid>> DeleteCategoryAsync();
    Task<Result<List<CategoryDto>>> GetAll();

}
