public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public int CityId { get; set; }
    public string? CityTitle { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public int? Coworkers { get; set; }
}
