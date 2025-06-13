using CustomerManagement.Application.Customers.Dtos;
using CustomerManagement.Application.Customers.Queries;
using CustomerManagement.Domain.Interfaces;
using MediatR;

namespace CustomerManagement.Application.Customers.Handlers;

public class GetCustomerHandler :
    IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>,
    IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
{
    private readonly ICustomerRepository _repo;

    public GetCustomerHandler(ICustomerRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _repo.GetAllAsync();
        return customers.Select(c => new CustomerDto
        {
            Id = c.Id,
            Name = c.Name,
            Address = c.Address,
            CityId = c.CityId,
            Phone = c.Phone,
            Fax = c.Fax,
            Coworkers = c.Coworkers
        }).ToList();
    }

    public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var c = await _repo.GetByIdAsync(request.Id);
        if (c == null) return null;

        return new CustomerDto
        {
            Id = c.Id,
            Name = c.Name,
            Address = c.Address,
            CityId = c.CityId,
            Phone = c.Phone,
            Fax = c.Fax,
            Coworkers = c.Coworkers
        };
    }
}
