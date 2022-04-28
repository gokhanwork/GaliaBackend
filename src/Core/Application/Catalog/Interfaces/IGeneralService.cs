using Galia.Application.Common.Interfaces;
using Galia.Application.Wrapper;
using Galia.Shared.DTOs.Catalog.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Application.Catalog.Interfaces;

public interface IGeneralService : ITransientService
{
    Task<Result<List<UnitDto>>> GetAllUnitsAsync();
}
