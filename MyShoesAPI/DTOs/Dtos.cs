using System.Collections.Generic;
using MyShoesAPI.Models;

namespace MyShoesAPI.Dtos
{
    public class RegisterDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public required AddressDto Address { get; set; }
    }

    public class LoginDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class AuthResponse
    {
        public required string Token { get; set; }
        public required UserDto User { get; set; }
    }

    public class ProductDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string Category { get; set; }
        public required string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required AddressDto Address { get; set; }
        public required string Role { get; set; }
    }

    public class AddressDto
    {
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }
    }

    public class CreateOrderDto
    {
        public required List<OrderItemDto> OrderItems { get; set; }
        public required AddressDto ShippingAddress { get; set; }
        public required string PaymentMethod { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
} 