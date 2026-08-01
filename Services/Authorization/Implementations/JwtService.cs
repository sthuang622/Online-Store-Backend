using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Online_Store_Backend_WebAPI.Models.Configurations;
using Online_Store_Backend_WebAPI.Services.Authorization.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Online_Store_Backend_WebAPI.Services.Authorization.Implementations;

public class JwtService : IJwtService
{
    private readonly AuthorizationOptions _authorizationOptions;

    public JwtService(IOptions<AuthorizationOptions> authorizationOptions)
    {
        _authorizationOptions = authorizationOptions.Value;
    }

    public string CreateToken(string userId, string email)
    {
        var role = ""; //get from db

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_authorizationOptions.SecretKey)
        );

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _authorizationOptions.Issuer,
            audience: _authorizationOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_authorizationOptions.JwtDuration),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
