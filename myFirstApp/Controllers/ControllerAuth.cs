using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myFirstApp.Data;
using myFirstApp.Security.Model;
using myFirstApp.Security.Service;

namespace myFirstApp.Controllers;

[Route("api/v1/auth/")]
[ApiController]
public class ControllerAuth : ControllerBase //for exceptions
{
    
    private readonly ApplicationDbContext _context; //all database configurations
    
    private readonly TokenService _tokenService;

    public ControllerAuth(
        ApplicationDbContext context, 
        TokenService tokenService
        )
    {
        _context = context;
        _tokenService = tokenService;
    }


    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] Register register)
    {
        if(string.IsNullOrEmpty(register.Username) 
           || string.IsNullOrEmpty(register.Password))
        {
            return BadRequest("username or password empty");
        }
        var existingUser = await _context.Logins
            .FirstOrDefaultAsync(u 
                => u.Username == register.Username);

        if(existingUser != null)
        {
            return Conflict(" user already exists ");
        }

        var hashedPassword = 
            BCrypt.Net.BCrypt.HashPassword(register.Password);
        

        var newUser = new Register
        {
            Username = register.Username,
            Password = hashedPassword,
            Role = register.Role,

        };

        _context.Registers.Add(newUser);
        await _context.SaveChangesAsync();

        return Ok("successful registration");  
    }
    
    
    [HttpPost("Login")]
    [AllowAnonymous]
        
    public async Task<IActionResult> Login([FromBody] Login login)
    {
        if(string.IsNullOrEmpty(login.Username) 
           || string.IsNullOrEmpty(login.Password))
        {
            return BadRequest("username and login must be provided");
        }

        var user = await _context.Registers
            .FirstOrDefaultAsync(u => u.Username == login.Username);

        if(user == null)
        {
            return Unauthorized("incorrect username or password");
        }
            
        if(!BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
        {
            return Unauthorized("authentication error");
        }

        var existingLogin = await _context.Logins
            .FirstOrDefaultAsync(l => l.Username == login.Username);

        if(existingLogin != null)
        {
            var token = _tokenService.GenerateToken(login.Username, user.Role);
            return Ok(new
            {
                Token = token
            });
        }

        _context.Logins.Add(login);
        await _context.SaveChangesAsync();

        var newToken = _tokenService.GenerateToken(login.Username, user.Role);
            

        return Ok(new { 
            Token = newToken
                
        });
    }
    
    
}