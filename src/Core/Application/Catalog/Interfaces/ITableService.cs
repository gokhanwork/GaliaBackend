using Galia.Application.Common.Interfaces;
using Galia.Application.Wrapper;
using Galia.Domain.Catalog;
using Galia.Shared.DTOs.Catalog.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Application.Catalog.Interfaces;

public interface ITableService : ITransientService
{
    Task<Result<List<TableDto>>> GetAllTableAsync();
    Task<Result<Guid>> CreateTableAsync(CreateTableRequest request);
    Task<Result<Guid>> DeleteTableAsync();
    Task<Result<Guid>> UpdateTableAsync();
}
