using CustomerManagement.Application.Common.Interfaces;
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
    private readonly ICurrentUserService _currentUser;

    public ManageCustomerHandler(ICustomerRepository repo, ICurrentUserService currentUser)
    {
        _repo = repo;
        _currentUser = currentUser;
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
            Coworkers = request.Customer.Coworkers,
            CreatedBy = _currentUser.UserId
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
        customer.UpdatedAt = DateTime.Now;
        customer.EditedBy = _currentUser.UserId;

        await _repo.UpdateAsync(customer);
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repo.GetByIdAsync(request.Id);
        if (customer != null)
        {
            customer.DeletedBy = _currentUser.UserId;
            customer.DeletedAt = DateTime.Now;

            await _repo.DeleteAsync(customer);
        }
    }
}
