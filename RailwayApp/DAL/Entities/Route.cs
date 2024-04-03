namespace DAL.Entities;

public class Route
{
    public int Id { get; set; }
    public TimeOnly DurationTime { get; set; }
    public decimal FullRoutePrice { get; set; }
    public int TrainId { get; set; }
    public Train? Train { get; set; }
    public List<RouteStop> RouteStops { get; set; } = new();
    public List<Ticket> Tickets { get; set; } = new();
}