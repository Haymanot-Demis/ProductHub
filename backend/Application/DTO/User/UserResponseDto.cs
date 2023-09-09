using Application.DTO.Common;

namespace Application.DTO.User;

public class UserResponseDto : BaseDto
{
    public string UserName { get; set; } = "";
    public string Email { get; set; } = "";
}