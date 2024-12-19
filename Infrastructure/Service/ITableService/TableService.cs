using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Service.ITableService;

public class TableService(DapperContext context):ITableService
{
    public Task<Response<List<Table>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> Create(Table table)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> Update(Table table)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<Table>>> GetEmpty()
    {
        throw new NotImplementedException();
    }
}