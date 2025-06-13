using CustomerManagement.Application.Customers.Commands;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces;
using MediatR;

namespace CustomerManagement.Application.Customers.Handlers;

public class ManageCustomerHandler :
    IRequestHandler<CreateCustomerCommand, int>,
    IRequestHandler<UpdateCustomerCommand>,
    IRequestHandler<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _repo;

    public ManageCustomerHandler(ICustomerRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Customer
        {
            Name = request.Customer.Name,
            Address = request.Customer.Address,
            CityId = request.Customer.CityId,
            Phone = request.Customer.Phone,
            Fax = request.Customer.Fax,
            Coworkers = request.Customer.Coworkers
        };

        await _repo.AddAsync(entity);
        return entity.Id;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repo.GetByIdAsync(request.Customer.Id);
        if (customer == null) return;

        customer.Name = request.Customer.Name;
        customer.Address = request.Customer.Address;
        customer.CityId = request.Customer.CityId;
        customer.Phone = request.Customer.Phone;
        customer.Fax = request.Customer.Fax;
        customer.Coworkers = request.Customer.Coworkers;

        await _repo.UpdateAsync(customer);
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repo.GetByIdAsync(request.Id);
        if (customer != null)
        {
            await _repo.DeleteAsync(customer);
        }
    }
}
