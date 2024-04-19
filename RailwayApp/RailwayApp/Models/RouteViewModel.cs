using System.ComponentModel.DataAnnotations;
using BLL.DTO;

namespace RailwayApp.Models;

public class RouteViewModel
{
    public int TrainId { get; set; }
    public TrainDTO? Train { get; set; }
    
    [Required(ErrorMessage = "Не указано время поездки")]
    [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Некорректный формат времени")]
    public TimeOnly DurationTime { get; set; }
    
    [Required(ErrorMessage = "Не указана полная стоимость поездки")]
    public decimal FullRoutePrice { get; set; }
    
    [Required(ErrorMessage = "Не указаны остановки")]
    [RegularExpression(@"^(\S+\s*){2,}$", ErrorMessage = "В списке должно быть хотя бы два элемента")]
    public List<RouteStopViewModel>? Stops { get; set; }
}