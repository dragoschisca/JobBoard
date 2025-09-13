using JobBoard_API.Application.DTOs.CandidatDto;
using JobBoard_API.Application.DTOs.UserDto;
using JobBoard_API.Application.Interfaces.Data;
using JobBoard_API.Domain.Entites;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard_API.WebApi.Controllers;

[Route("/api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly ApplicationDbContext dbContext;

    public UserController(ApplicationDbContext dbcontext)
    {
        this.dbContext = dbcontext;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(dbContext.Users.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(Guid id)
    {
        return Ok(dbContext.Users.Find(id));
    }

    [HttpPost]
    public IActionResult AddUser(AddUserDto addUserDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new User()
        {
            Email = addUserDto.Email,
            Password = addUserDto.Password,
            Role = UserRole.Admin,
        };
        
        dbContext.Add(user);
        dbContext.SaveChanges();
        
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, UpdateUserDto updateUserDto)
    {
        var user = dbContext.Users.Find(id);
        
        user.Email = updateUserDto.Email;
        user.Password = updateUserDto.Password;
        
        dbContext.Update(user);
        dbContext.SaveChanges();
        
        return Ok(user);
    }
    

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        var user = dbContext.Users.Find(id);
        dbContext.Users.Remove(user);
        dbContext.SaveChanges();
        return Ok(user);
    }
}