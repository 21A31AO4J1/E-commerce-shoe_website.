using System;
using System.ComponentModel.DataAnnotations;

namespace MyShoesAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public required string Category { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public required string Brand { get; set; }

        [Required]
        public required string Size { get; set; }

        [Required]
        public required string Color { get; set; }

        [Required]
        public required string ImageUrl { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
    }
} 