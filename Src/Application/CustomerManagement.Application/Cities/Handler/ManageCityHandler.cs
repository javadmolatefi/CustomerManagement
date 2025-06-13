using CustomerManagement.Application.Cities.Commands;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces;
using MediatR;

namespace CustomerManagement.Application.Cities.Handlers;

public class ManageCityHandler :
    IRequestHandler<CreateCityCommand, int>,
    IRequestHandler<UpdateCityCommand>,
    IRequestHandler<DeleteCityCommand>
{
    private readonly ICityRepository _repo;

    public ManageCityHandler(ICityRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var entity = new City
        {
            Title = request.City.Title
        };

        await _repo.AddAsync(entity);
        return entity.Id;
    }

    public async Task Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _repo.GetByIdAsync(request.City.Id);
        if (city == null) return;

        city.Title = request.City.Title;

        await _repo.UpdateAsync(city);
    }

    public async Task Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _repo.GetByIdAsync(request.Id);
        if (city != null)
        {
            await _repo.DeleteAsync(city);
        }
    }
}
