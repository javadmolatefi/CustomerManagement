namespace CustomerManagement.Application.Common.Interfaces;

public interface ILogService
{
    Task LogAsync(string action, string entityName, int? entityId = null, string? details = null);
}
