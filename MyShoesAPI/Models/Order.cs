using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyShoesAPI.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public required User User { get; set; }

        [Required]
        public required List<OrderItem> OrderItems { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public required Address ShippingAddress { get; set; }

        public required string PaymentMethod { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public required Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }
        public required Product Product { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
} 