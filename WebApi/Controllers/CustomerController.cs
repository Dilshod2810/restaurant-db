using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpGet("GetAllCustomers")]
    public async Task<Response<List<Customer>>> GetAll()
    {
        var response = await customerService.GetAll();
        return response;
    }
    [HttpGet("GetCustomerByPhone")]
    public async Task<Response<Customer>> GetCustomerById(string phoneNumber)
    {
        return customerService.GetByPhone(phoneNumber).Result;
    }

    [HttpPost("AddCustomer")]
    public async Task<Response<bool>> Create(Customer customer)
    {
        var response = await customerService.Create(customer);
        return response;
    }

    [HttpGet("GetCustomerByName")]
    public async Task<Response<Customer>> GetCustomerByName(string name)
    {
        var response = await customerService.GetCustomerByName(name);
        return response;
    }

    [HttpDelete("DeleteCustomer")]
    public async Task<Response<bool>> Delete(int id)
    {
        var response = await customerService.Delete(id);
        return response;
    }
    
}