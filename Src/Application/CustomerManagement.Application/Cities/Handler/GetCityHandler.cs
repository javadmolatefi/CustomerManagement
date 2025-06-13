using CustomerManagement.Application.Cities.Dtos;
using CustomerManagement.Application.Cities.Queries;
using CustomerManagement.Domain.Interfaces;
using MediatR;

namespace CustomerManagement.Application.Cities.Handlers;

public class GetCityHandler :
    IRequestHandler<GetAllCitiesQuery, List<CityDto>>,
    IRequestHandler<GetCityByIdQuery, CityDto?>
{
    private readonly ICityRepository _repo;

    public GetCityHandler(ICityRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<CityDto>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        var cities = await _repo.GetAllAsync();
        return cities.Select(c => new CityDto
        {
            Id = c.Id,
            Title = c.Title
        }).ToList();
    }

    public async Task<CityDto?> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var city = await _repo.GetByIdAsync(request.Id);
        if (city == null) return null;

        return new CityDto
        {
            Id = city.Id,
            Title = city.Title
        };
    }
}
