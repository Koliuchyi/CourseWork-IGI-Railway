using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class TicketDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Не указано место")]
    public int SeatNumber { get; set; }
    
    [Required(ErrorMessage = "Не указана цена билета")]
    public decimal TicketPrice { get; set; }
    public string? DepartureStation { get; set; }
    public string? ArrivalStation { get; set; }
    public int RouteId { get; set; }
    public RouteDTO? Route { get; set; }
    public int ClientId { get; set; }
    public ClientDTO? Client { get; set; }
}