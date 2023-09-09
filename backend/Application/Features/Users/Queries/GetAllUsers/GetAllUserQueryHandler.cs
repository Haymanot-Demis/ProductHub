using Application.Contracts.Persistence;
using Application.DTO.User;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Queries.GetAllUsers;

public class GetAllUserQueryHandler: IRequestHandler<GetAllUsersQuery, List<UserResponseDto>> 
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<List<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserResponseDto>>(users);
    }
}