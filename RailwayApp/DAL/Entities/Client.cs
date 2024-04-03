using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

public class Client
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    [EmailAddress(ErrorMessage = "Некорректный формат адреса электронной почты")]
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ContactNumber { get; set; }
    public string? PassportData { get; set; }
    public List<Ticket> Tickets { get; set; } = new();
}