using System;
using System.ComponentModel.DataAnnotations;

namespace MyShoesAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; }

        public int? AddressId { get; set; }
        public required Address Address { get; set; }

        [Phone]
        public required string Phone { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
} 