namespace CustomerManagement.Application.Common.Identity;

public interface IIdentityService
{
    Task<string?> RegisterAsync(string email, string password);
    Task<string?> LoginAsync(string email, string password);
}
