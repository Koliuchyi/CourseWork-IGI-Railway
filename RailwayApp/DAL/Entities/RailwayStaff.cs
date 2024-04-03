using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

public class RailwayStaff
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; }
    [EmailAddress(ErrorMessage = "Некорректный формат адреса электронной почты")]
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ContactNumber { get; set; }
    public string? PassportData { get; set; }
}