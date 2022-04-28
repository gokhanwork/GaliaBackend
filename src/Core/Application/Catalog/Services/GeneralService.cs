using Galia.Application.Catalog.Interfaces;
using Galia.Application.Common.Interfaces;
using Galia.Application.Wrapper;
using Galia.Shared.DTOs.Catalog.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galia.Domain.Catalog;
using Mapster;

namespace Galia.Application.Catalog.Services;

public class GeneralService : IGeneralService
{
    private readonly IRepositoryAsync _repository;

    public GeneralService(IRepositoryAsync repository)
    {
        _repository = repository;
    }

    // Units

    public async Task<Result<List<UnitDto>>> GetAllUnitsAsync()
    {
        var units = await _repository.GetListAsync<Unit>(null, true);
        var mappedUnits = units.Adapt<List<UnitDto>>();
        return await Result<List<UnitDto>>.SuccessAsync(mappedUnits);
    }

}