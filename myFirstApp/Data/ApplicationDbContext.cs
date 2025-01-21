using Microsoft.EntityFrameworkCore;
using myFirstApp.Models;

namespace myFirstApp.Data;

public class ApplicationDbContext : DbContext
{

       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
       {
              
       } 
    
       public DbSet<User> Users { get; set; }
}