using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class StationDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Не указано название станции")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина названия станции должна быть до 30 символов")]
    public string? Name { get; set; }
    public List<RouteStopDTO>? RouteStops { get; set; }
    public int CityId { get; set; }
    public CityDTO? City { get; set; }
}