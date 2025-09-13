using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard_API.Domain.Entites;

public class Admin : User
{
    public string Name {get; set;}
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}