using Blazored.LocalStorage;
using System.Net.Http.Json;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public AuthService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

    public async Task<bool> LoginAsync(AuthRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/Auth/login", request);
        if (!response.IsSuccessStatusCode) return false;

        var token = await response.Content.ReadAsStringAsync();
        await _localStorage.SetItemAsync("token", token);
        _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        return true;
    }

    public async Task<bool> RegisterAsync(AuthRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/Auth/register", request);
        if (!response.IsSuccessStatusCode) return false;

        var token = await response.Content.ReadAsStringAsync();
        await _localStorage.SetItemAsync("token", token);
        _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        return true;
    }
}
