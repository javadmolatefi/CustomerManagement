using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Persistence.Repositories;

public class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext _context;
    public CityRepository(ApplicationDbContext context) => _context = context;

    public async Task<List<City>> GetAllAsync() =>
        await _context.Cities
            .Where(c => !c.IsDeleted)
            .ToListAsync();

    public async Task<City?> GetByIdAsync(int id) =>
        await _context.Cities
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

    public async Task AddAsync(City city)
    {
        await _context.Cities.AddAsync(city);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(City city)
    {
        _context.Cities.Update(city);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(City city)
    {
        city.IsDeleted = true;
        city.DeletedAt = DateTime.Now;
        _context.Cities.Update(city);
        await _context.SaveChangesAsync();
    }
}
