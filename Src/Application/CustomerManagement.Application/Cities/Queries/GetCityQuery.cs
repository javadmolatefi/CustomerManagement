using CustomerManagement.Application.Cities.Dtos;
using MediatR;

namespace CustomerManagement.Application.Cities.Queries;

public record GetAllCitiesQuery() : IRequest<List<CityDto>>;
public record GetCityByIdQuery(int Id) : IRequest<CityDto?>;
