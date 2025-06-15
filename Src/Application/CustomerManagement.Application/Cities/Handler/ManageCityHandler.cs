using CustomerManagement.Application.Cities.Commands;
using CustomerManagement.Application.Common.Interfaces;
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
    private readonly ICurrentUserService _currentUser;

    public ManageCityHandler(ICityRepository repo, ICurrentUserService currentUser)
    {
        _repo = repo;
        _currentUser = currentUser;
    }

    public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var entity = new City
        {
            Title = request.City.Title,
            CreatedBy = _currentUser.UserId
        };

        await _repo.AddAsync(entity);
        return entity.Id;
    }

    public async Task Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _repo.GetByIdAsync(request.City.Id);
        if (city == null) return;

        city.Title = request.City.Title;
        city.UpdatedAt = DateTime.Now;
        city.EditedBy = _currentUser.UserId;

        await _repo.UpdateAsync(city);
    }

    public async Task Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _repo.GetByIdAsync(request.Id);
        if (city != null)
        {
            city.DeletedBy = _currentUser.UserId;
            city.DeletedAt = DateTime.Now;

            await _repo.DeleteAsync(city);
        }
    }
}
