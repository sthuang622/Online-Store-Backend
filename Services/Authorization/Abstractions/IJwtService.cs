namespace Online_Store_Backend_WebAPI.Services.Authorization.Abstractions;

public interface IJwtService
{
    string CreateToken(string userId, string email);
}
