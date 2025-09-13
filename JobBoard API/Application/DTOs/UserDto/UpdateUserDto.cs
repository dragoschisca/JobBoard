using System.ComponentModel.DataAnnotations;

namespace JobBoard_API.Application.DTOs.UserDto;

public class UpdateUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}