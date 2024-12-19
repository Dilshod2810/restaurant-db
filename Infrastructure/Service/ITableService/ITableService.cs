using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service.ITableService;

public interface ITableService
{
    Task<Response<List<Table>>> GetAll();
    Task<Response<bool>> Create(Table table);
    Task<Response<bool>> Update(Table table);
    Task<Response<bool>> Delete(int id);
    Task<Response<List<Table>>> GetEmpty();
}