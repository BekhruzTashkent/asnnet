using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

namespace myFirstApp.Security.Service;

public class TokenService
{
    
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    // public string GenerateToken(string username, string role)
    // {
    //     var claims = new List<Claim>()
    //     {
    //         new Claim(ClaimTypes.Name, username),
    //         new Claim(ClaimTypes.Role, role)
    //     };
    //     var token = new JwtSecurityToken(
    //         issuer: "Issuer",
    //         audience: "Audience",
    //         claims: claims,
    //         expires: DateTime.UtcNow.AddDays(7),
    //         signingCredentials: new SigningCredentials(
    //             new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bexruzkarimov7777")), 
    //             SecurityAlgorithms.HmacSha256));
    //
    //     return new JwtSecurityTokenHandler().WriteToken(token);
    // }
    
    
    public string GenerateToken(string username, string role)
    {
        var keyString = _configuration.GetValue<string>("JwtConfig:Key");
        var issuer = _configuration.GetValue<string>("JwtConfig:Issuer");
        var audience = _configuration.GetValue<string>("JwtConfig:Audience");
    
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };
    
        if (keyString != null)
        {
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString)), 
                    SecurityAlgorithms.HmacSha256));
    
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    
        return null;
    }
    
    
    // public string GenerateToken(IEnumerable<Claim> claims)
    // {
    //     var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Secret"]));
    //     var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
    //
    //     var tokenOptions = new JwtSecurityToken(
    //         issuer: _configuration["JwtConfig:Issuer"],
    //         audience: _configuration["JwtConfig:Audience"],
    //         claims: claims,
    //         expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtConfig:AccessExpiration"])),
    //         signingCredentials: signinCredentials
    //     );
    //
    //     return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    // }
    

    
}