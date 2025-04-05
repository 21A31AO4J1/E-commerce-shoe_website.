using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShoesAPI.Data;
using MyShoesAPI.Dtos;
using MyShoesAPI.Helpers;
using MyShoesAPI.Models;
using System.Security.Claims;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace MyShoesAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtHelper _jwtHelper;

        public AuthService(ApplicationDbContext context, IJwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }

        public async Task<AuthResponse> Register(RegisterDto registerDto)
        {
            // Validate email format
            if (!IsValidEmail(registerDto.Email))
            {
                throw new ValidationException("Invalid email format");
            }

            // Validate phone number format
            if (!IsValidPhoneNumber(registerDto.Phone))
            {
                throw new ValidationException("Invalid phone number format");
            }

            // Check if user already exists
            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
            {
                throw new ValidationException("User with this email already exists");
            }

            // Validate password strength
            if (!IsPasswordStrong(registerDto.Password))
            {
                throw new ValidationException("Password must contain at least one uppercase letter, one lowercase letter, one number and one special character");
            }

            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PasswordHash = HashPassword(registerDto.Password),
                Role = "User",
                Phone = registerDto.Phone,
                Address = new Address
                {
                    Street = registerDto.Address.Street,
                    City = registerDto.Address.City,
                    State = registerDto.Address.State,
                    ZipCode = registerDto.Address.ZipCode,
                    Country = registerDto.Address.Country
                }
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = _jwtHelper.GenerateToken(user);
            return new AuthResponse
            {
                Token = token,
                User = MapToUserDto(user)
            };
        }

        public async Task<AuthResponse> Login(LoginDto loginDto)
        {
            // Validate email format
            if (!IsValidEmail(loginDto.Email))
            {
                throw new ValidationException("Invalid email format");
            }

            var user = await _context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                throw new ValidationException("Invalid email or password");
            }

            var token = _jwtHelper.GenerateToken(user);
            return new AuthResponse
            {
                Token = token,
                User = MapToUserDto(user)
            };
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ValidationException("User not found");
            }

            return MapToUserDto(user);
        }

        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new ValidationException("User not found");
            }

            if (!VerifyPassword(currentPassword, user.PasswordHash))
            {
                throw new ValidationException("Current password is incorrect");
            }

            if (!IsPasswordStrong(newPassword))
            {
                throw new ValidationException("New password must contain at least one uppercase letter, one lowercase letter, one number and one special character");
            }

            user.PasswordHash = HashPassword(newPassword);
            await _context.SaveChangesAsync();
            return true;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\+?[\d\s-]{10,}$");
        }

        private bool IsPasswordStrong(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
        }

        private UserDto MapToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                Address = new AddressDto
                {
                    Street = user.Address.Street,
                    City = user.Address.City,
                    State = user.Address.State,
                    ZipCode = user.Address.ZipCode,
                    Country = user.Address.Country
                }
            };
        }
    }
} 