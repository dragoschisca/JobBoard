namespace MyBlazorClient.Shared;

public class CandidatDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CvPath { get; set; }
    public ICollection<string> Skills { get; set; } = new List<string>();
}