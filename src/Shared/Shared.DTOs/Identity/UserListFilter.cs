using Galia.Shared.DTOs.Filters;

namespace Galia.Shared.DTOs.Identity;

public class UserListFilter : PaginationFilter
{
    public bool? IsActive { get; set; }
}
