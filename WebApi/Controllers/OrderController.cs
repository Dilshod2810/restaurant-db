using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Service.IOrderService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService):ControllerBase
{
    [HttpGet("GetAllCustomers")]
    public async Task<Response<List<Order>>> GetAll()
    {
        var response = await orderService.GetAll();
        return response;
    }
    [HttpGet("GetCustomerById")]
    public async Task<Response<Order>> GetOrderById(int id)
    {
        return orderService.GetOrderById(id).Result;
    }

    [HttpPost("AddCustomer")]
    public async Task<Response<bool>> Create(Order order)
    {
        var response = await orderService.Create(order);
        return response;
    }

    [HttpPut("UpdateCustomer")]
    public async Task<Response<bool>> Update(Order order)
    {
        var response = await orderService.Update(order);
        return response;
    }

    // [HttpDelete("DeleteCustomer")]
    // public async Task<Response<bool>> Delete(int id)
    // {
    //     var response = await orderService.Delete(id);
    //     return response;
    // }

}