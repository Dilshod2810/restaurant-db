using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service.IMenuItemService;

public interface IMenuItemService
{
    Task<Response<List<MenuItem>>> GetAll();
    Task<Response<bool>> Create(MenuItem menuItem);
}