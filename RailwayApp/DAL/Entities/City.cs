namespace DAL.Entities;

public class City
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? EngName { get; set; }
    public string? Description { get; set; }
    public string? Photo { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public List<Station> Stations { get; set; } = new();
}