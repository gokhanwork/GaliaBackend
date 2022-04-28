using Galia.Application.Common.Interfaces;
using Galia.Application.Wrapper;
using Galia.Shared.DTOs.Catalog;
using Galia.Shared.DTOs.Catalog.Product;

namespace Galia.Application.Catalog.Interfaces;

public interface IProductService : ITransientService
{
    Task<Result<ProductDetailsDto>> GetProductDetailsAsync(Guid id);

    Task<Result<ProductDto>> GetByIdUsingDapperAsync(Guid id);

    Task<PaginatedResult<ProductDto>> SearchAsync(ProductListFilter filter);

    Task<Result<Guid>> CreateProductAsync(CreateProductRequest request);

    Task<Result<Guid>> UpdateProductAsync(UpdateProductRequest request, Guid id);

    Task<Result<Guid>> DeleteProductAsync(Guid id);

    // TODO: Burada isPosListing Yapýlabilir.
    Task<Result<List<ProductPosDto>>> GetProductPosList();
}
