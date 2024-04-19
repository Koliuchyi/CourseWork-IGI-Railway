namespace DAL.Entities;

public class Train
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CarriageCount { get; set; }
    public int TypeTrainId { get; set; }
    public TypeTrain? TypeTrain { get; set; }
    public int CarriageId { get; set; }
    public Carriage? Carriage { get; set; }
    public Route? Route { get; set; }
}