using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class CityDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Не указано имя")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина имени должна быть до 30 символов")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Не указано имя")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина имени должна быть до 30 символов")]
    public string? EngName { get; set; }
    
    [Required]
    public string? Description { get; set; }

    [Required]
    public string? Photo { get; set; }
    
    public int CountryId { get; set; }
    public CountryDTO? Country { get; set; }
    public List<StationDTO> Stations { get; set; } = new();
}