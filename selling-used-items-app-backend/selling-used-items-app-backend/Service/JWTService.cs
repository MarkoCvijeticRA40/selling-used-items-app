using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using selling_used_items_app_backend.Service;

public class JWTService : IJWTService
{
    public JWTService() { }

    public string GenerateToken(string email, string password)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("email", email),
                new Claim("password", password)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        return unixEpoch.AddSeconds(unixTimeStamp).ToLocalTime();
    }

    public bool IsTokenExpired(string token)
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