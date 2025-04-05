using MyShoesAPI.Models;

namespace MyShoesAPI.Helpers
{
    public interface IJwtHelper
    {
        string GenerateToken(User user);
    }
} 