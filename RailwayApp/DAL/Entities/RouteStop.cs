namespace DAL.Entities;

public class RouteStop
{
    public int Id { get; set; }
    public int SequenceNumber { get; set; }
    public DateOnly DepartureDate { get; set; }
    public DateOnly ArrivalDate { get; set; }
    public TimeOnly DepartureTime { get; set; }
    public TimeOnly ArrivalTime { get; set; }
    public int RouteId { get; set; }
    public Route? Route { get; set; }
    public int StationId { get; set; }
    public Station? Station { get; set; }
}