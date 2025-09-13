using JobBoard_API.Application.DTOs.CandidatDto;
using JobBoard_API.Application.Interfaces.Data;
using JobBoard_API.WebApi.Controllers;
using JobBoard_API.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobBoard_API.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CandidatController : ControllerBase
{
    private readonly ApplicationDbContext dbcontext;

    public CandidatController(ApplicationDbContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    [HttpGet]
    public IActionResult GetAllCandidats()
    {
        return Ok(dbcontext.Candidats.ToList());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCandidatById(Guid id)
    {
        return Ok(dbcontext.Candidats.Find(id));
    }
    
    [HttpPost]
    public IActionResult AddCandidat([FromBody] AddCandidatDto addCandidatDto)
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }

        var candidat = new Candidat()
        {
            Email = addCandidatDto.Email,
            Password = addCandidatDto.Password,
            Role = UserRole.Candidate,
            FirstName = addCandidatDto.FirstName,
            LastName = addCandidatDto.LastName,
            CvPath = addCandidatDto.CvPath,
            Skills = addCandidatDto.Skills
        };
        
        dbcontext.Users.Add(candidat); 
        dbcontext.SaveChanges();

        return Ok(candidat);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCandidat(Guid id, UpdateCandidatDto updateCandidatDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var candidat = dbcontext.Candidats.Find(id);
        
        candidat.FirstName = updateCandidatDto.FirstName;
        candidat.LastName = updateCandidatDto.LastName;
        candidat.CvPath = updateCandidatDto.CvPath;
        candidat.Skills = updateCandidatDto.Skills;
        
        dbcontext.SaveChanges();
        return Ok(candidat);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCandidat(Guid id)
    {
        var candidat = dbcontext.Candidats.Find(id);
        dbcontext.Candidats.Remove(candidat);
        dbcontext.SaveChanges();
        return Ok();
    }
    
}