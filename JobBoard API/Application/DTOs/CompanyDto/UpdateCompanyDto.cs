using JobBoard_API.Domain.Entites;

namespace JobBoard_API.Application.DTOs.CompanyDto;

public class UpdateCompanyDto
{
    public string CompanyName { get; set; }
    public string City { get; set; }
    public string OfficeAddress { get; set; }
    public string OfficePhone { get; set; }
    public ICollection<Guid> JobIds { get; set; } = new List<Guid>();}