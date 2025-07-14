using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Models;

public class ExpenseEntry
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public int Amount { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
