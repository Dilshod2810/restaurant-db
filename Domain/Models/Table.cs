namespace Domain.Models;

public class Table
{
// 2. **Tables** (Столики):
// - `Id`: уникальный идентификатор.
// - `TableNumber`: номер столика.
// - `IsOccupied`: статус занятости (true/false).
    public int TableId { get; set; }
    public int TableNumber { get; set; }
    public bool IsOccupied { get; set; }
}