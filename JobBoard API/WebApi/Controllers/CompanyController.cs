using JobBoard_API.Application.DTOs.CompanyDto;
using JobBoard_API.Application.Interfaces.Data;
using JobBoard_API.Domain.Entites;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard_API.WebApi.Controllers;

[Route("/api/[controller]")]
[ApiController]

public class CompanyController : ControllerBase
{
    private readonly ApplicationDbContext dbcontext;

    public CompanyController(ApplicationDbContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    [HttpGet]
    public IActionResult GetAllCompanies()
    {
        return Ok(dbcontext.Companies.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetCompanyById(int id)
    {
        return Ok(dbcontext.Users.Find(id));
    }

    [HttpPost]
    public IActionResult AddCompany([FromBody] AddCompanyDto addCompanyDto)
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }
        
        var jobs = dbcontext.Jobs
            .Where(j => addCompanyDto.JobIds.Contains(j.Id))
            .ToList();

        var company = new Company()
        {
            Email = addCompanyDto.Email,
            Password = addCompanyDto.Password,
            Role = UserRole.Company,
            CompanyName = addCompanyDto.CompanyName,
            City = addCompanyDto.City,
            OfficeAddress = addCompanyDto.OfficeAddress,
            OfficePhone = addCompanyDto.OfficePhone,
            JobIds = jobs.Select(j => j.Id).ToList()
        };

        dbcontext.Users.Add(company);
        dbcontext.SaveChanges();


        return Ok(company);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCompany(Guid id, [FromBody] UpdateCompanyDto updateCompanyDto)
    {
        var company = dbcontext.Companies.Find(id);
        
        company.CompanyName = updateCompanyDto.CompanyName;
        company.OfficeAddress = updateCompanyDto.OfficeAddress;
        company.OfficePhone = updateCompanyDto.OfficePhone;
        company.City = updateCompanyDto.City;
        company.JobIds = updateCompanyDto.JobIds;
        
        dbcontext.SaveChanges();
        return Ok(company);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCompany(Guid id)
    {
        var company = dbcontext.Companies.Find(id);
        dbcontext.Companies.Remove(company);
        dbcontext.SaveChanges();
        return Ok();
    }
}