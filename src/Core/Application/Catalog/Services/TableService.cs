using Galia.Application.Catalog.Interfaces;
using Galia.Application.Common.Interfaces;
using Galia.Application.Exceptions;
using Galia.Application.Wrapper;
using Galia.Domain.Catalog;
using Galia.Domain.Catalog.Events;
using Galia.Domain.Dashboard;
using Galia.Shared.DTOs.Catalog.Table;
using Mapster;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galia.Application.Catalog.Services;

public class TableService : ITableService
{
    private readonly IRepositoryAsync _repository;
    private readonly IStringLocalizer<TableService> _localizer;
    public TableService(IRepositoryAsync repository, IStringLocalizer<TableService> localizer)
    {
        _repository = repository;
        _localizer = localizer;
    }

    public async Task<Result<Guid>> CreateTableAsync(CreateTableRequest request)
    {
        bool tableExists = await _repository.ExistsAsync<Table>(t => t.TableName == request.TableName);
        if (tableExists) throw new EntityAlreadyExistsException(string.Format(_localizer["table.alreadyexists"], request.TableName));
        var table = new Table(request.TableName, request.TableStatus);
        table.DomainEvents.Add(new TableCreatedEvent(table));
        table.DomainEvents.Add(new StatsChangedEvent());

        var tableId = await _repository.CreateAsync(table);
        await _repository.SaveChangesAsync();
        return await Result<Guid>.SuccessAsync(tableId);

    }

    public Task<Result<Guid>> DeleteTableAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<TableDto>>> GetAllTableAsync()
    {
        var tables = await _repository.GetListAsync<Table>(null, true);
        var mappedTables = tables.Adapt<List<TableDto>>();
        return await Result<List<TableDto>>.SuccessAsync(mappedTables);
    }

    public Task<Result<Guid>> UpdateTableAsync()
    {
        throw new NotImplementedException();
    }
}
