using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class CountryDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Не указано название страны")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина названия страны должна быть до 30 символов")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Не указано фото страны")]
    public string? Photo { get; set; }
    
    public List<CityDTO> Cities { get; set; } = new();
}