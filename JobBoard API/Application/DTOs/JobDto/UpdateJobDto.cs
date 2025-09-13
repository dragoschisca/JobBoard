using System.ComponentModel.DataAnnotations.Schema;
using JobBoard_API.Domain.Entites;

namespace JobBoard_API.Application.DTOs.JobDto;

public class UpdateJobDto
{
    string Title { get; set; }
    string Description { get; set; }
    string Skills { get; set; }
    int IsSalaryMentionated { get; set; }
    int? Salary { get; set; }
    Experience Experience { get; set; }
    WorkTime WorkTime { get; set; }
    Location Location { get; set; }
    DateTime CreatedOn { get; set; }

    Guid CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    Company Company { get; set; }
}