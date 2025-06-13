using CustomerManagement.Application.Customers.Dtos;

namespace CustomerManagement.Application.Customers;

public interface ICustomerFacade
{
    Task<List<CustomerDto>> GetAllAsync();
    Task<CustomerDto?> GetByIdAsync(int id);
    Task<int> CreateAsync(CustomerDto customer);
    Task UpdateAsync(CustomerDto customer);
    Task DeleteAsync(int id);
}
