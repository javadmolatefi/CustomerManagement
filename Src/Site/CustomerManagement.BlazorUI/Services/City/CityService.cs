using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;

public class CityService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public CityService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

    private async Task PrepareAuthHeaderAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("token");
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<List<CityDto>> GetAllAsync()
    {
        await PrepareAuthHeaderAsync();
        return await _http.GetFromJsonAsync<List<CityDto>>("api/City") ?? new();
    }

    public async Task<CityDto?> GetByIdAsync(int id)
    {
        await PrepareAuthHeaderAsync();
        return await _http.GetFromJsonAsync<CityDto>($"api/City/{id}");
    }

    public async Task CreateAsync(CityDto dto)
    {
        await PrepareAuthHeaderAsync();
        await _http.PostAsJsonAsync("api/City", dto);
    }

    public async Task UpdateAsync(CityDto dto)
    {
        await PrepareAuthHeaderAsync();
        await _http.PutAsJsonAsync($"api/City/{dto.Id}", dto);
    }

    public async Task DeleteAsync(int id)
    {
        await PrepareAuthHeaderAsync();
        await _http.DeleteAsync($"api/City/{id}");
    }
}
