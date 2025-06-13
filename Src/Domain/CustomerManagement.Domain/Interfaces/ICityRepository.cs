using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Domain.Interfaces;

public interface ICityRepository
{
    Task<List<City>> GetAllAsync();
    Task<City?> GetByIdAsync(int id);
    Task AddAsync(City city);
    Task UpdateAsync(City city);
    Task DeleteAsync(City city);
}
