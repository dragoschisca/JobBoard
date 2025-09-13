namespace JobBoard_API.Application.DTOs.CandidatDto;

public class AddCandidatDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CvPath { get; set; }
    public ICollection<string> Skills { get; set; } = new List<string>();
}