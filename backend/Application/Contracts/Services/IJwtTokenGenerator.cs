namespace Application.Contracts.Services;

public interface IJwtTokenGenerator
{
    public string GenerateToken(string email, string username, int id);
}