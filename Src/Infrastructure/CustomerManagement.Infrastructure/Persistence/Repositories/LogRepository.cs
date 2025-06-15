using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces;

namespace CustomerManagement.Infrastructure.Persistence.Repositories;

public class LogRepository : ILogRepository
{
    private readonly ApplicationDbContext _context;

    public LogRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(LogEntry log)
    {
        await _context.Logs.AddAsync(log);
        await _context.SaveChangesAsync();
    }
}
