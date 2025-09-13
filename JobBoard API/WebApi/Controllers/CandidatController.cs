using JobBoard_API.Application.DTOs.CandidatDto;
using JobBoard_API.Application.Interfaces.Data;
using JobBoard_API.WebApi.Controllers;
using JobBoard_API.Domain.Entites;
using Microsoft.AspNetCore.Mvc;

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
        dbcontext.Candidats.ToList();
        return Ok();
    }

    [HttpPost]
    public IActionResult AddCandidat([FromBody] AddCandidatDto addCandidatDto)
    {
        if(!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }
        
        var candidat = new Candidat()
        {
            FirstName = addCandidatDto.FirstName,
            LastName = addCandidatDto.LastName,
            CvPath = addCandidatDto.CvPath,
            Skills = addCandidatDto.Skills,
        };
        
        dbcontext.Candidats.Add(candidat);
        dbcontext.SaveChanges();
        return Ok(candidat);
    }
    
}