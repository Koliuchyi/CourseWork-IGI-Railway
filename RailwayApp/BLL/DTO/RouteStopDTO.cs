using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class RouteStopDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Не указан номер остановки")]
    [Range(1, 100, ErrorMessage = "Значение должно быть больше 0")]
    public int SequenceNumber { get; set; }
    
    [Required(ErrorMessage = "Не указана дата отправления")]
    [RegularExpression(@"^\d{2}\.\d{2}\.\d{4}$", ErrorMessage = "Дата должна быть в формате дд.мм.гггг")]
    public DateOnly DepartureDate { get; set; }

    [Required(ErrorMessage = "Не указана дата прибытия")]
    [RegularExpression(@"^\d{2}\.\d{2}\.\d{4}$", ErrorMessage = "Дата должна быть в формате дд.мм.гггг")]
    public DateOnly ArrivalDate { get; set; }

    [Required(ErrorMessage = "Не указано время отправления")]
    [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Некорректный формат времени")]
    public TimeOnly DepartureTime { get; set; }

    [Required(ErrorMessage = "Не указано время прибытия")]
    [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Некорректный формат времени")]
    public TimeOnly ArrivalTime { get; set; }
    
    public int RouteId { get; set; }
    public RouteDTO? Route { get; set; }
    public int StationId { get; set; }
    public StationDTO? Station { get; set; }
}