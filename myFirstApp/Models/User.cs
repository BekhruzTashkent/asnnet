using System.ComponentModel.DataAnnotations;

namespace myFirstApp.Models;

public class User
{
    
    public int id { get; set; }
    
    [Required]
    public string username { get; set; }
    
    [Required]
    public string password { get; set; }
    
    public string? email { get; set; }
    
    private string? phoneNumber { get; set; }
    
    
    
}