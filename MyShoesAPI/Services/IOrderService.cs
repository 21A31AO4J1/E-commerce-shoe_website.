using System.Collections.Generic;
using System.Threading.Tasks;
using MyShoesAPI.DTOs;
using MyShoesAPI.Models;

namespace MyShoesAPI.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(int userId, CreateOrderDto createOrderDto);
        Task<IEnumerable<OrderDto>> GetUserOrdersAsync(int userId);
        Task<OrderDto> GetOrderByIdAsync(int userId, int orderId);
        Task UpdateOrderStatusAsync(int orderId, OrderStatus status);
        Task UpdatePaymentStatusAsync(int orderId, PaymentStatus status);
    }
} 