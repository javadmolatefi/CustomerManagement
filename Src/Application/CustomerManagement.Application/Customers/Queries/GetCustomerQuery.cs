using CustomerManagement.Application.Customers.Dtos;
using MediatR;

namespace CustomerManagement.Application.Customers.Queries;

public record GetAllCustomersQuery() : IRequest<List<CustomerDto>>;
public record GetCustomerByIdQuery(int Id) : IRequest<CustomerDto?>;
