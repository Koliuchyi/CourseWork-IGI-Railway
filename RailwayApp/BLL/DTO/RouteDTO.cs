using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class RouteDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Не указано время поездки")]
    [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Некорректный формат времени")]
    public TimeOnly DurationTime { get; set; }
    
    [Required(ErrorMessage = "Не указана полная стоимость поездки")]
    public decimal FullRoutePrice { get; set; }
    
    public int TrainId { get; set; }
    public TrainDTO? Train { get; set; }
    public List<RouteStopDTO> RouteStops { get; set; } = new();
    public List<TicketDTO> Tickets { get; set; } = new();
}