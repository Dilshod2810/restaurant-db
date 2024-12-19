using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Service.IOrderService;

public class OrderService(DapperContext context):IOrderService
{
    public async Task<Response<List<Order>>> GetAll()
    {
        string sql = "select * from orders";
        var res = await context.Connection().QueryAsync<Order>(sql);
        return new Response<List<Order>>(res.ToList());
    }

    public async Task<Response<bool>> Create(Order order)
    {
        string sql = "insert into orders(customerid, tableid, status) values(@CustomerId, @TableId, @Status);";
        var res = await context.Connection().ExecuteAsync(sql);
        return res > 0
            ? new Response<bool>(HttpStatusCode.Created, "Created successufully")
            : new Response<bool>(HttpStatusCode.BadRequest, "Bad Request");
    }

    public async Task<Response<bool>> Update(Order order)
    {
        string sql =
            "update orders set customerid=@CustomerId, tableid=@TableId, status=@Status where orderid=@OrderId";
        var res = await context.Connection().ExecuteAsync(sql, order);
        return res>0 
            ? new Response<bool>(HttpStatusCode.OK, "Updated successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Not found");
    }

    public async Task<Response<Order>> GetOrderById(int id)
    {
        string sql = "select * from orders where orderid = @Id";
        var order = await context.Connection().QuerySingleOrDefaultAsync<Order>(sql, new { Id = id });
        return order == null
            ? new Response<Order>(HttpStatusCode.NotFound, "Not found")
            : new Response<Order>(HttpStatusCode.OK, "Already exists");
    }
}