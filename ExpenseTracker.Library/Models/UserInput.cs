namespace ExpenseTracker.Library.Models;

public class UserInput
{
    public string? Description { get; set; }
    public int Amount { get; set; } = -1;
    public int Id { get; set; } = -1;
    public int Month { get; set; } = -1;
}
