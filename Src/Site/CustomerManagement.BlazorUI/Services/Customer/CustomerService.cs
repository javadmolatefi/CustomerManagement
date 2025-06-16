using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;

public class CustomerService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public CustomerService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

    private async Task PrepareAuthHeaderAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("token");
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<List<CustomerDto>> GetAllAsync()
    {
        await PrepareAuthHeaderAsync();
        return await _http.GetFromJsonAsync<List<CustomerDto>>("api/Customer") ?? new();
    }

    public async Task<CustomerDto?> GetByIdAsync(int id)
    {
        await PrepareAuthHeaderAsync();
        return await _http.GetFromJsonAsync<CustomerDto>($"api/Customer/{id}");
    }

    public async Task CreateAsync(CustomerDto dto)
    {
        await PrepareAuthHeaderAsync();
        await _http.PostAsJsonAsync("api/Customer", dto);
    }

    public async Task UpdateAsync(CustomerDto dto)
    {
        await PrepareAuthHeaderAsync();
        await _http.PutAsJsonAsync($"api/Customer/{dto.Id}", dto);
    }

    public async Task DeleteAsync(int id)
    {
        await PrepareAuthHeaderAsync();
        await _http.DeleteAsync($"api/Customer/{id}");
    }
}
