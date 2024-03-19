using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using selling_used_items_app_backend.Service;

public class JWTService : IJWTService
{
    private readonly IConfiguration _configuration;

    public JWTService(IConfiguration configuration) {
        _configuration = configuration;
    }

    public string GenerateToken(string email, string password, string role)
    {
        List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, role),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }   

    private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        return unixEpoch.AddSeconds(unixTimeStamp).ToLocalTime();
    }

    public bool isTokenExpired(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            if (securityToken is JwtSecurityToken jwtSecurityToken)
            {
                var expiration = jwtSecurityToken.ValidTo;
                return expiration <= DateTime.UtcNow;
            }
        }
        catch
        {
            return true;
        }
        return false;
    }
}
