using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace myFirstApp.Security.Model;

public class Register
{
    
    [JsonIgnore]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    public string Role { get; set; }
}