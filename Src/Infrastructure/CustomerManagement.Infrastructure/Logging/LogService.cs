using CustomerManagement.Application.Common.Interfaces;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces;

namespace CustomerManagement.Infrastructure.Logging;

public class LogService : ILogService
{
    private readonly ILogRepository _logRepository;
    private readonly ICurrentUserService _currentUser;

    public LogService(ILogRepository logRepository, ICurrentUserService currentUser)
    {
        _logRepository = logRepository;
        _currentUser = currentUser;
    }

    public async Task LogAsync(string action, string entityName, int? entityId = null, string? details = null)
    {
        var log = new LogEntry
        {
            Action = action,
            EntityName = entityName,
            EntityId = entityId,
            Details = details,
            UserId = _currentUser.UserId,
            CreatedAt = DateTime.Now,
            CreatedBy = _currentUser.UserId,
            UserName = _currentUser.UserId
        };

        await _logRepository.AddAsync(log);
    }
}
