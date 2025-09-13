using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobBoard_API.Domain.Entites;
public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; } 
}

public enum UserRole
{
    Admin,
    Candidate,
    Company
}
