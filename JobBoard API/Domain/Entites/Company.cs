using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard_API.Domain.Entites;

public class Company : User
{
    public string CompanyName { get; set; }
    public string City { get; set; }
    public string OfficeAddress { get; set; }
    public string OfficePhone { get; set; }
    public ICollection<Job> Jobs { get; set; } = new List<Job>();
}
