using CustomerManagement.Application.Cities.Dtos;

namespace CustomerManagement.Application.Cities;

public interface ICityFacade
{
    Task<List<CityDto>> GetAllAsync();
    Task<CityDto?> GetByIdAsync(int id);
    Task<int> CreateAsync(CityDto city);
    Task UpdateAsync(CityDto city);
    Task DeleteAsync(int id);
}
