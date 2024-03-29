namespace DAL.Entities;

public class Ticket
{
    public int Id { get; set; }
    public int SeatNumber { get; set; }
    public decimal TicketPrice { get; set; }
    public int RouteId { get; set; }
    public Route? Route { get; set; }
    public int TicketId { get; set; }
    public Client? Client { get; set; }
}