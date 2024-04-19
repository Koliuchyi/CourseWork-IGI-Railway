using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class TypeTrainDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Не указан тип поезда")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина типа должна быть до 20 символов")]
    public string? TypeName { get; set; }
    
    [Required(ErrorMessage = "Отсутствует описание")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Отсутствует фото")]
    public string? Photo { get; set; }
    
    public TrainDTO? Train { get; set; } 
}