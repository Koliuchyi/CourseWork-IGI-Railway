using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class TrainDTO
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Не указано название поезда")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина имени должна быть до 20 символов")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Не указано кол-во вагонов в поезде")]
    [Range(1, 100, ErrorMessage = "Значение должно быть больше 0")]
    public int CarriageCount { get; set; }
    
    
    public int TypeTrainId { get; set; }
    public TypeTrainDTO? TypeTrain { get; set; }
    public int CarriageId { get; set; }
    public CarriageDTO? Carriage { get; set; }
    public RouteDTO? Route { get; set; }
}