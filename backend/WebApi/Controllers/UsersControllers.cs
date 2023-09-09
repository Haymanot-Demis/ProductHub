using Application.DTO.User;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Queries.GetAllUsers;
using Application.Features.Users.Queries.GetUserById;
using Application.Features.Users.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersControllers : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("All")]
    public async Task<ActionResult<List<UserResponseDto>>> GetAll()
    {
        return await _mediator.Send(new GetAllUsersQuery());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> GetById(int id)
    {
        return await _mediator.Send(new GetUserByIdQuery(){UserId = id});
    }
    
    // Register
    [HttpPost("Register")]
    public async Task<ActionResult<UserResponseDto>> Create([FromBody] CreateUserDto createUserDto)
    {
        return await _mediator.Send(new CreateUserCommand(){CreateUserDto = createUserDto});
    }
    
    // Login
    [HttpPost("Login")]
    public async Task<AuthResponse> Login([FromBody] LoginDto loginDto)
    {
        return await _mediator.Send(new LoginQuery(){LoginDto = loginDto});
    }
    
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<UserResponseDto>> Update(int id, [FromBody] CreateUserDto createUserDto)
    {
        return await _mediator.Send(new UpdateUserCommand(){UserId = id, CreateUserDto = createUserDto});
    }
}