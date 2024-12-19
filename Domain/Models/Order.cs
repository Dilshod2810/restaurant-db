namespace Domain.Models;

public class Order
{
// 4. **Orders** (Заказы):
// - `Id`: уникальный идентификатор.
// - `CustomerId`: ID клиента.
// - `TableId`: ID столика.
// - `Status`: статус заказа (В ожидании, Готовится, Подан, Завершен).
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int TableId { get; set; }
    public string Status { get; set; }
}