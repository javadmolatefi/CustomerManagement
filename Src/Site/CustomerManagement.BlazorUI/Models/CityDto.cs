using System.ComponentModel.DataAnnotations;

public class CityDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "City name is required.")]
    [MaxLength(100, ErrorMessage = "City name must not exceed 100 characters.")]
    public string Title { get; set; } = string.Empty;
}
