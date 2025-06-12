using CustomerManagement.Domain.Common;

namespace CustomerManagement.Domain.Entities;

public class City : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
