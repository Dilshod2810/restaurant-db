namespace Domain.Models;

public class OrderItem
{
// 5. **OrderItems** (Состав заказа):
// - `Id`: уникальный идентификатор.
// - `OrderId`: ID заказа.
// - `MenuItemId`: ID блюда.
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int MenuItemId { get; set; }
}