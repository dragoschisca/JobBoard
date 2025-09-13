using JobBoard_API.Domain.Entites;

namespace JobBoard_API.Request.DTOs.RequestDto;

public class AddRequestDto
{
    Guid Id { get; init; }
    Guid JobId { get; set; }
    Guid UserId { get; set; }
    Status Status { get; set; }
}