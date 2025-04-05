using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShoesAPI.DTOs;
using MyShoesAPI.Services;
using System.Security.Claims;
using MyShoesAPI.Models;

namespace MyShoesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(CreateOrderDto createOrderDto)
        {
            var userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
            var order = await _orderService.CreateOrderAsync(userId, createOrderDto);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetUserOrders()
        {
            var userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
            var orders = await _orderService.GetUserOrdersAsync(userId);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
            var order = await _orderService.GetOrderByIdAsync(userId, id);
            return Ok(order);
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusDto updateStatusDto)
        {
            await _orderService.UpdateOrderStatusAsync(id, updateStatusDto.Status);
            return NoContent();
        }

        [HttpPut("{id}/payment")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePaymentStatus(int id, [FromBody] UpdatePaymentStatusDto updatePaymentDto)
        {
            await _orderService.UpdatePaymentStatusAsync(id, updatePaymentDto.PaymentStatus);
            return NoContent();
        }
    }
} 