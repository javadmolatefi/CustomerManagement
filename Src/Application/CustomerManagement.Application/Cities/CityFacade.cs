using CustomerManagement.Application.Cities.Commands;
using CustomerManagement.Application.Cities.Dtos;
using CustomerManagement.Application.Cities.Queries;
using MediatR;

namespace CustomerManagement.Application.Cities;

public class CityFacade : ICityFacade
{
    private readonly IMediator _mediator;
    public CityFacade(IMediator mediator) => _mediator = mediator;

    public Task<List<CityDto>> GetAllAsync() => _mediator.Send(new GetAllCitiesQuery());
    public Task<CityDto?> GetByIdAsync(int id) => _mediator.Send(new GetCityByIdQuery(id));
    public Task<int> CreateAsync(CityDto city) => _mediator.Send(new CreateCityCommand(city));
    public Task UpdateAsync(CityDto city) => _mediator.Send(new UpdateCityCommand(city));
    public Task DeleteAsync(int id) => _mediator.Send(new DeleteCityCommand(id));
}
