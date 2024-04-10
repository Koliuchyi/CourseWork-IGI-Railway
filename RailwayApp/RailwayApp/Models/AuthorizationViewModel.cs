using System.ComponentModel.DataAnnotations;

namespace RailwayApp.Models;

public class AuthorizationViewModel
{
    [Required(ErrorMessage = "Не указан логин")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина логина должна быть до 30 символов")]
    [EmailAddress(ErrorMessage = "Некорректный формат адреса электронной почты")]
    public string? Login { get; set; }
    [Required(ErrorMessage = "Не указан пароль")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина пароля должна быть до 30 символов")]
    public string? Password { get; set; }
}