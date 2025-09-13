using JobBoard_API.Application.Interfaces.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard_API.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RequestController : ControllerBase
{
    private readonly ApplicationDbContext dbcontext;

    public RequestController(ApplicationDbContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    [HttpGet]
    public IActionResult GetAllRequests()
    {
        return Ok(dbcontext.Requests.ToList());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetAllRequestForCandidat(Guid id)
    {
        var result = dbcontext.Requests.Where(r => r.UserId == id).ToList();
        return Ok(result);
    }
}