namespace MyBlazorClient.Shared;

public class JobDto
{
    
    public string Title { get; set; }
    public string Description { get; set; }
    public string Skills { get; set; }
    public int IsSalaryMentionated { get; set; }
    public int? Salary { get; set; }
    public string Category { get; set; }
    public DateTime CreatedOn { get; set; }
}