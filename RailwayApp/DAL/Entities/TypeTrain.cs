namespace DAL.Entities;

public class TypeTrain
{
    public int Id { get; set; }
    public string? TypeName { get; set; }
    public string? Description { get; set; }
    public string? Photo { get; set; }
    public Train? Train { get; set; } 
}