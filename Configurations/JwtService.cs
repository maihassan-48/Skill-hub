using Microsoft.IdentityModel.Tokens;
using Skill_Hub.Enums;
using Skill_Hub.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Skill_Hub.Configurations;

public class JwtService
{
    private readonly IConfiguration _config;

    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(User user, Role role)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, ((int)role).ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(_config["Jwt:DurationInMinutes"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public int GetUserIdFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
        {
            return userId;
        }
        throw new ArgumentException("Invalid token or user ID not found in token");
    }
}
