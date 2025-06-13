using CustomerManagement.Application.Cities.Dtos;
using MediatR;

namespace CustomerManagement.Application.Cities.Commands;

public record CreateCityCommand(CityDto City) : IRequest<int>;
public record UpdateCityCommand(CityDto City) : IRequest;
public record DeleteCityCommand(int Id) : IRequest;
