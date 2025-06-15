using CustomerManagement.Application.Cities.Commands;
using CustomerManagement.Application.Cities.Dtos;
using CustomerManagement.Application.Cities.Queries;
using CustomerManagement.Application.Common.Interfaces;
using MediatR;

namespace CustomerManagement.Application.Cities;

public class CityFacade : ICityFacade
{
    private readonly IMediator _mediator;
    private readonly ILogService _log;

    public CityFacade(IMediator mediator, ILogService log)
    {
        _mediator = mediator;
        _log = log;
    }

    public Task<List<CityDto>> GetAllAsync() => _mediator.Send(new GetAllCitiesQuery());
    public Task<CityDto?> GetByIdAsync(int id) => _mediator.Send(new GetCityByIdQuery(id));

    public async Task<int> CreateAsync(CityDto city)
    {
        var id = await _mediator.Send(new CreateCityCommand(city));
        await _log.LogAsync("Create", "City", id, $"City '{city.Title}' created.");
        return id;
    }

    public async Task UpdateAsync(CityDto city)
    {
        await _mediator.Send(new UpdateCityCommand(city));
        await _log.LogAsync("Update", "City", city.Id, $"City '{city.Title}' updated.");
    }

    public async Task DeleteAsync(int id)
    {
        await _mediator.Send(new DeleteCityCommand(id));
        await _log.LogAsync("Delete", "City", id, $"City ID {id} deleted.");
    }
}
