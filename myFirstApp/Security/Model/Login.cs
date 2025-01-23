using System.Text.Json.Serialization;

namespace myFirstApp.Security.Model;

public class Login
{
    [JsonIgnore]
    public int Id { get; set; }
    
    public string Username { get; set; }
    
    public string Password { get; set; }
    
}