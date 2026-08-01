namespace Online_Store_Backend_WebAPI.Models.Configurations;

public class AuthorizationOptions
{
    public double JwtDuration { get; set; } = 60;

    public string SecretKey { get; set; } = string.Empty;

    public string Issuer { get; set; } = string.Empty;

    public string Audience { get; set; } = string.Empty;
}
