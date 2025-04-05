using System.ComponentModel.DataAnnotations;

namespace MyShoesAPI.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public required string Street { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string State { get; set; }

        [Required]
        public required string ZipCode { get; set; }

        [Required]
        public required string Country { get; set; }
    }
} 