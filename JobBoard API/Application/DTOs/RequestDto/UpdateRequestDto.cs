using JobBoard_API.Domain.Entites;
namespace JobBoard_API.Application.DTOs.ApplicationDto;

public class UpdateRequestDto
{
    Guid Id { get; init; }
    Guid JobId { get; set; }
    Guid UserId { get; set; }
    Status Status { get; set; }
}