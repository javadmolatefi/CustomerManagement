using CustomerManagement.Application.Customers.Commands;
using CustomerManagement.Application.Customers.Dtos;
using CustomerManagement.Application.Customers.Queries;
using MediatR;

namespace CustomerManagement.Application.Customers;

public class CustomerFacade : ICustomerFacade
{
    private readonly IMediator _mediator;

    public CustomerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<CustomerDto>> GetAllAsync()
    {
        return await _mediator.Send(new GetAllCustomersQuery());
    }

    public async Task<CustomerDto?> GetByIdAsync(int id)
    {
        return await _mediator.Send(new GetCustomerByIdQuery(id));
    }

    public async Task<int> CreateAsync(CustomerDto customer)
    {
        return await _mediator.Send(new CreateCustomerCommand(customer));
    }

    public async Task UpdateAsync(CustomerDto customer)
    {
        await _mediator.Send(new UpdateCustomerCommand(customer));
    }

    public async Task DeleteAsync(int id)
    {
        await _mediator.Send(new DeleteCustomerCommand(id));
    }
}
