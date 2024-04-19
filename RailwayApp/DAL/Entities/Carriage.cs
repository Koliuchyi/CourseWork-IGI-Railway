namespace DAL.Entities;

public class Carriage
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int PlacesCount { get; set; }
    public Train? Train { get; set; }
    public int TypeCarriageId { get; set; }
    public TypeCarriage? TypeCarriage { get; set; }
}