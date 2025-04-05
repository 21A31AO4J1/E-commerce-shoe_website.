using System.Threading.Tasks;
using MyShoesAPI.Dtos;
using MyShoesAPI.Models;

namespace MyShoesAPI.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> Register(RegisterDto registerDto);
        Task<AuthResponse> Login(LoginDto loginDto);
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
    }
} 