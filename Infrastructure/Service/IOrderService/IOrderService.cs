using System.Diagnostics;
using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service.IOrderService;

public interface IOrderService
{
    Task<Response<List<Order>>> GetAll();
    Task<Response<bool>> Create(Order order);
    Task<Response<bool>> Update(Order order);
    Task<Response<Order>> GetOrderById(int id);
}