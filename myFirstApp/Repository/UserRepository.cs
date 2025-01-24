using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using myFirstApp.Data;
using myFirstApp.Interface;
using myFirstApp.Models;

namespace myFirstApp.Repository;

 public class UserRepository : UserService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        

        public UserRepository(IConfiguration configuration,
            ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex) 
            {
                throw new Exception("error in creating user", ex);
            }
        }
        

        // public async Task<bool> ValidateTokenAsync(string token)
        // {
        //    try
        //     {
        //         var tokenHandler = new JwtSecurityTokenHandler();
        //         var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        //
        //         tokenHandler.ValidateToken(token, new TokenValidationParameters
        //         {
        //             ValidateIssuer = true,
        //             ValidateAudience = true,
        //             ValidateLifetime = true,
        //             ValidateIssuerSigningKey = true,
        //             ValidIssuer = _configuration["Jwt:Issuer"],
        //             ValidAudience = _configuration["Jwt: Audience"],
        //             IssuerSigningKey = new SymmetricSecurityKey(key),
        //         }, out SecurityToken validatedToken);
        //         return validatedToken != null;
        //         
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }

    }