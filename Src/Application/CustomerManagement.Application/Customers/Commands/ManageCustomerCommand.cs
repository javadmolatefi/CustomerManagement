using CustomerManagement.Application.Customers.Dtos;
using MediatR;

namespace CustomerManagement.Application.Customers.Commands;

public record CreateCustomerCommand(CustomerDto Customer) : IRequest<int>;
public record UpdateCustomerCommand(CustomerDto Customer) : IRequest;
public record DeleteCustomerCommand(int Id) : IRequest;
