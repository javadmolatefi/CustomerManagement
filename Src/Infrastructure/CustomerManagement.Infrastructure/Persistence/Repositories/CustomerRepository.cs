using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers
            .Include(c => c.City)
            .Where(c => !c.IsDeleted)
            .ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Customers
            .Include(c => c.City)
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Customer customer)
    {
        customer.IsDeleted = true;
        customer.DeletedAt = DateTime.Now;
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }
}
