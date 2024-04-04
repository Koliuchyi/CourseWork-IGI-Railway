using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class TypeCarriageDTO
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Не указан тип вагона")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина типа должна быть до 20 символов")]
    public string? TypeName { get; set; }
    
    [Required]
    public string? Photo { get; set; }

    public CarriageDTO? Carriage { get; set; }
}