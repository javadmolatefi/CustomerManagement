using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Domain.Interfaces;

public interface ILogRepository
{
    Task AddAsync(LogEntry log);
}
