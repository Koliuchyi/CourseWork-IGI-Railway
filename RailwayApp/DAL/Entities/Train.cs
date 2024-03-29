namespace DAL.Entities;

public class Train
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CarriageCount { get; set; }
    public int TypeTrainId { get; set; }
    public TypeTrain? TypeTrain { get; set; }
    public List<Carriage> Carriages { get; set; } = new();
    public Route? Route { get; set; }
}