namespace Domain.Models;

public class MenuItem
{
// 3. **MenuItems** (Пункты меню):
// - `Id`: уникальный идентификатор.
// - `Name`: название блюда.
// - `Price`: цена.
// - `Category`: категория блюда.
    public int MenuItemId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}