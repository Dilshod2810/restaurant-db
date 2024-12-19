namespace Domain.Models;

public class Customer
{
// 1. **Customers** (Клиенты):
// - `Id`: уникальный идентификатор.
// - `Name`: имя клиента.
// - `PhoneNumber`: номер телефона.
    public int CustomerId { get; set; }
    public string  Name { get; set; }
    public string PhoneNumber { get; set; }
}