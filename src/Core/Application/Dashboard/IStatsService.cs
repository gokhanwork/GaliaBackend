using Galia.Application.Common.Interfaces;
using Galia.Application.Wrapper;
using Galia.Shared.DTOs;

namespace Galia.Application.Dashboard;

public interface IStatsService : ITransientService
{
    Task<IResult<StatsDto>> GetDataAsync();
}
