namespace DAL.Entities;

public class TypeCarriage
{
    public int Id { get; set; }
    public string? TypeName { get; set; }
    public string? Photo { get; set; }
    public Carriage? Carriage { get; set; }
}