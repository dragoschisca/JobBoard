using System.ComponentModel.DataAnnotations.Schema;
using JobBoard_API.Domain.Entites;

namespace JobBoard_API.Application.DTOs.JobDto;

public class AddJobDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Skills { get; set; }
    public int IsSalaryMentionated { get; set; }
    public int? Salary { get; set; }
    public string Category { get; set; }
    public Experience Experience { get; set; }
    public WorkTime WorkTime { get; set; }
    public Location Location { get; set; }
    public DateTime CreatedOn { get; set; }

    public Guid CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company Company { get; set; }
}