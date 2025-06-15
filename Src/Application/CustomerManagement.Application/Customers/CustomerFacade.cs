using CustomerManagement.Application.Common.Interfaces;
using CustomerManagement.Application.Customers.Commands;
using CustomerManagement.Application.Customers.Dtos;
using CustomerManagement.Application.Customers.Queries;
using MediatR;

namespace CustomerManagement.Application.Customers;

public class CustomerFacade : ICustomerFacade
{
    private readonly IMediator _mediator;
    private readonly ILogService _log;

    public CustomerFacade(IMediator mediator, ILogService log)
    {
        _mediator = mediator;
        _log = log;
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
        var id = await _mediator.Send(new CreateCustomerCommand(customer));
        await _log.LogAsync("Create", "Customer", id, $"Customer '{customer.Name}' created.");
        return id;
    }

    public async Task UpdateAsync(CustomerDto customer)
    {
        await _mediator.Send(new UpdateCustomerCommand(customer));
        await _log.LogAsync("Update", "Customer", customer.Id, $"Customer '{customer.Name}' updated.");
    }

    public async Task DeleteAsync(int id)
    {
        await _mediator.Send(new DeleteCustomerCommand(id));
        await _log.LogAsync("Delete", "Customer", id, $"Customer ID {id} deleted.");
    }
}
