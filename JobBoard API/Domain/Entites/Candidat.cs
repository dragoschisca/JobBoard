using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard_API.Domain.Entites;

public class Candidat : User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CvPath { get; set; }
    public ICollection<string> Skills { get; set; } = new List<string>();
}