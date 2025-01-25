namespace Identity.Infrastructure;

public interface IJwtGenerator
{
    Task<string> GenerateToken(User user);
}