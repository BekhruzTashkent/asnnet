using Microsoft.EntityFrameworkCore;
using myFirstApp.Models;
using myFirstApp.Security.Model;

namespace myFirstApp.Data;

public class ApplicationDbContext : DbContext
{

       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
       {
              
       } 
    
       public DbSet<User> Users { get; set; }
       public DbSet<Group> Groups { get; set; }
       
       public DbSet<Login> Logins { get; set; }
       
       public DbSet<Register> Registers { get; set; }
}