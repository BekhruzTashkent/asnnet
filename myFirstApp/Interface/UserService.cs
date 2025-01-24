using myFirstApp.Models;

namespace myFirstApp.Interface;

public interface UserService
{
    Task<User> CreateUserAsync(User user );
}