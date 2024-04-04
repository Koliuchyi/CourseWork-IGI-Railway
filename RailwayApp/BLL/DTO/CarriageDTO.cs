using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class CarriageDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Не указано имя")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина имени должна быть до 20 символов")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Не указано кол-во свободных мест")]
    [Range(1, 100, ErrorMessage = "Значение должно быть больше 0")]
    public int PlacesCount { get; set; }
    
    public int TrainId { get; set; }
    public TrainDTO? Train { get; set; }
    public int TypeCarriageId { get; set; }
    public TypeCarriageDTO? TypeCarriage { get; set; }
}