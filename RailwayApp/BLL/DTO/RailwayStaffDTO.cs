using System.ComponentModel.DataAnnotations;

namespace BLL.DTO;

public class RailwayStaffDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Не указано имя")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина имени должна быть до 20 символов")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Не указана фамилия")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина фамилии должна быть до 20 символов")]
    public string? LastName { get; set; }
    
    [Required(ErrorMessage = "Не указана роль")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина роли должна быть до 20 символов")]
    public string? Role { get; set; }
    
    [Required(ErrorMessage = "Не указан логин")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина логина должна быть до 20 символов")]
    [EmailAddress(ErrorMessage = "Некорректный формат адреса электронной почты")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Не указан пароль")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина пароля должна быть до 20 символов")]
    public string? Password { get; set; }
    
    [Required(ErrorMessage = "Не указан номер телефона")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина номера телефона должна быть до 30 символов")]
    public string? ContactNumber { get; set; }
    
    [Required(ErrorMessage = "Не указаны паспортные данные")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина номера паспорта должна быть до 30 символов")]
    public string? PassportData { get; set; }
}