using CustomerManagement.Domain.Common;

namespace CustomerManagement.Domain.Entities;

public class LogEntry : BaseEntity
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string Action { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public int? EntityId { get; set; }
    public string? Details { get; set; }
}
