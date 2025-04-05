using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyShoesAPI.Dtos;
using MyShoesAPI.Models;

namespace MyShoesAPI.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        public required List<CreateOrderItemDto> OrderItems { get; set; }

        [Required]
        public required AddressDto ShippingAddress { get; set; }

        [Required]
        public required string PaymentMethod { get; set; }
    }

    public class CreateOrderItemDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required List<OrderItemDto> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
        public required string Status { get; set; }
        public required AddressDto ShippingAddress { get; set; }
        public required string PaymentMethod { get; set; }
        public required string PaymentStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderItemDetailDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class UpdateOrderStatusDto
    {
        public required OrderStatus Status { get; set; }
    }

    public class UpdatePaymentStatusDto
    {
        public required PaymentStatus PaymentStatus { get; set; }
    }
} 