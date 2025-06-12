using CustomerManagement.Domain.Common;

namespace CustomerManagement.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public int CityId { get; set; }
    public City? City { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public int? Coworkers { get; set; }
}
