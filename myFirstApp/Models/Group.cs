using System.ComponentModel.DataAnnotations;

namespace myFirstApp.Models;

public class Group
{
    
    public int Id { get; set; }
    
    [Required]
    public string GroupName { get; set; }
    
    public string? Description { get; set; }
    
}