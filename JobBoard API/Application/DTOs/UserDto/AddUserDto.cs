using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard_API.Application.DTOs.UserDto;

public class AddUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}