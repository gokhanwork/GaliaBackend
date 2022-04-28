using Galia.Application.Catalog.Interfaces;
using Galia.Application.Common.Interfaces;
using Galia.Application.Exceptions;
using Galia.Application.Specifications;
using Galia.Application.Storage;
using Galia.Application.Wrapper;
using Galia.Domain.Catalog;
using Galia.Domain.Common;
using Galia.Domain.Common.Contracts;
using Galia.Domain.Dashboard;
using Galia.Shared.DTOs.Catalog.Category;
using Mapster;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Application.Catalog.Services;

public class CategoryService : ICategoryService
{
    private readonly IStringLocalizer<CategoryService> _localizer;
    private readonly IRepositoryAsync _repository;
    private readonly IFileStorageService _file;

    public CategoryService(IStringLocalizer<CategoryService> localizer, IRepositoryAsync repository, IFileStorageService file)
    {
        _localizer = localizer;
        _repository = repository;
        _file = file;
    }

    public async Task<Result<Guid>> CreateCategoryAsync(CreateCategoryRequest request)
    {
        bool categoryExists = await _repository.ExistsAsync<Category>(c => c.Name == request.Name);
        if (categoryExists) throw new EntityAlreadyExistsException(string.Format(_localizer["category.alreadyexists"], request.Name));
        string categoryImagePath = await _file.UploadAsync<Category>(request.Image, FileType.Image);
        var category = new Category();
        if(request.ParentCategoryId == Guid.Empty)
        {
            category = new Category
            {
                Code = request.Code,
                Name = request.Name,
                Image = categoryImagePath
            };
        }
        else
        {
            category = new Category(request.Code, request.Name, categoryImagePath, request.ParentCategoryId);
        }

        category.DomainEvents.Add(new StatsChangedEvent());
        var categoryId = await _repository.CreateAsync<Category>(category);
        await _repository.SaveChangesAsync();
        return await Result<Guid>.SuccessAsync(categoryId);
    }

    public Task<Result<Guid>> DeleteCategoryAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<CategoryDto>>> GetAll()
    {
        var spec = new BaseSpecification<Category>();
        spec.Includes.Add(x => x.ParentCategory);
        var categories = await _repository.GetListForSpecAsync<Category>(null, true, spec);
        var mappedCategories = categories.Adapt<List<CategoryDto>>();
        return await Result<List<CategoryDto>>.SuccessAsync(mappedCategories);
    }

    public async Task<PaginatedResult<CategoryDto>> SearchAsync(CategoryListFilter filter)
    {
        var spec = new BaseSpecification<Category>();
        var filters = new Filters<Category>();
        filters.Add(filter.ParentCategoryId.HasValue, x => x.ParentCategoryId.Equals(filter.ParentCategoryId.Value));
        spec.Includes.Add(x => x.ParentCategory);
        return await _repository.GetSearchResultsAsync<Category, CategoryDto>(filter.PageNumber, spec, filter.PageSize, filter.OrderBy, filters, filter.AdvancedSearch, filter.Keyword);
    }

    public Task<Result<Guid>> UpdateCategoryAsync()
    {
        throw new NotImplementedException();
    }
}
