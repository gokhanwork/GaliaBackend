using Galia.Application.Catalog.Interfaces;
using Galia.Domain.Constants;
using Galia.Infrastructure.Identity.Permissions;
using Galia.Shared.DTOs.Catalog.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galia.Host.Controllers.Catalog;
public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    [MustHavePermission(PermissionConstants.Category.Register)]
    public async Task<IActionResult> CreateAsync(CreateCategoryRequest request)
    {
        return Ok(await _categoryService.CreateCategoryAsync(request));
    }

    [HttpPost("search")]
    [MustHavePermission(PermissionConstants.Category.View)]
    public async Task<IActionResult> Search(CategoryListFilter filter)
    {
        var categories = await _categoryService.SearchAsync(filter);
        return Ok(categories);
    }

    [HttpGet("get-all")]
    [MustHavePermission(PermissionConstants.Category.View)]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAll();
        return Ok(categories);
    }
}
