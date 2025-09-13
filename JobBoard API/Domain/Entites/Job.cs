using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard_API.Domain.Entites;

public class Job
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Skills { get; set; }
    public int IsSalaryMentionated { get; set; }
    public int? Salary { get; set; }
    public Experience Experience { get; set; }
    public WorkTime WorkTime { get; set; }
    public Location Location { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    
    public Guid CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }
    
}

public enum WorkTime
{
    FullTime,
    PartTime,
    FlexibleTime,
    InTurns
}

public enum Experience
{
    NoExperience,
    SmallExperience,
    MediumExperience,
    LargeExperience,
}

public enum Location
{
    Remote,
    Local,
    Hibrid
}