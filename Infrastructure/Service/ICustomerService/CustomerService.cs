using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Service;

public class CustomerService(DapperContext context):ICustomerService
{
    public async Task<Response<List<Customer>>> GetAll()
    {
        string sql = "select * from customers";
        var res = await context.Connection().QueryAsync<Customer>(sql);
        return new Response<List<Customer>>(res.ToList());
    }

    public async Task<Response<bool>> Create(Customer customer)
    {
        string sql = "insert into customers(name, phonenumber) values(@Name, @PhoneNumber);";
        var res = await context.Connection().ExecuteAsync(sql);
        return res > 0
            ? new Response<bool>(HttpStatusCode.Created, "Created successufully")
            : new Response<bool>(HttpStatusCode.BadRequest, "Bad Request");
    }

    public async Task<Response<Customer>> GetByPhone(string phoneNumber)
    {
        string sql = "select * from customers where phonenumber=@PhoneNumber";
        var res = await context.Connection()
            .QuerySingleOrDefaultAsync<Customer>(sql, new { PhoneNumber = phoneNumber });
        return res == null
            ? new Response<Customer>(HttpStatusCode.NotFound, "Not Found")
            : new Response<Customer>(HttpStatusCode.OK, "Ok");
    }

    public async Task<Response<Customer>> GetCustomerByName(string name)
    {
        string sql = "select * from customers where name=@Name";
        var res = await context.Connection()
            .QuerySingleOrDefaultAsync<Customer>(sql, new { Name = name });
        return res == null
            ? new Response<Customer>(HttpStatusCode.NotFound, "Not Found")
            : new Response<Customer>(HttpStatusCode.OK, "Ok");
    }

    public async Task<Response<bool>> Delete(int id)
    {
        string sql = "delete from customers where customerid=@Id";
        var res = await context.Connection().ExecuteAsync(sql, new { Id = id });
        return res > 0
            ? new Response<bool>(HttpStatusCode.OK, "Deleted")
            : new Response<bool>(HttpStatusCode.NotFound, "Not found");
    }

    public async Task<Response<decimal>> SumOfOrders(int id)
    {
        string sql = @"select sum(price) as total from MenuItems
                     join OrderItems on OrderItems.menuitemid = MenuItems.menuitemid
                     join orders ON orders.orderid = OrderItems.orderid
                     where orders.customerid = @Id";
        var res = await context.Connection().ExecuteScalarAsync<decimal>(sql, new { Id = id });
        return res == null
            ? new Response<decimal>(HttpStatusCode.InternalServerError, "Error")
            : new Response<decimal>(HttpStatusCode.OK, "OK");
    }
}