using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class NewsTableDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Не указан заголовок")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина заголовка должна быть до 20 символов")]
    public string? Title { get; set; }
    
    [Required(ErrorMessage = "Не указано описание")]
    public string? Description { get; set; }
    
    [Required]
    public string? Photo { get; set; }
}