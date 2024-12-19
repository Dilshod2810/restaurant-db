using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service;

public interface ICustomerService
{
    Task<Response<List<Customer>>> GetAll();
    Task<Response<bool>> Create(Customer customer);
    Task<Response<Customer>> GetByPhone(string phoneNumber);
    Task<Response<Customer>> GetCustomerByName(string name);
    Task<Response<bool>> Delete(int id);
    Task<Response<decimal>> SumOfOrders(int id);
}