using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Application.Customers.Dtos;

public class CustomerDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Customer name is required.")]
    [MaxLength(100, ErrorMessage = "Customer name must not exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(250, ErrorMessage = "Address must not exceed 250 characters.")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "City selection is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "A valid city must be selected.")]
    public int CityId { get; set; }

    [Phone(ErrorMessage = "Phone number is not valid.")]
    public string? Phone { get; set; }

    public string? CityTitle { get; set; }
    public string? Fax { get; set; }
    public int? Coworkers { get; set; }
}
