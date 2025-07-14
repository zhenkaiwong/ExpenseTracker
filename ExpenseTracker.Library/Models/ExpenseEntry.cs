using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Models;

public class ExpenseEntry
{
    public int Id { get; private set; }
    public string? Description { get; private set; }
    public int Amount { get; private set; }
    public DateTime Created { get; private set; }

    public DateTime Updated { get; private set; }

    public ExpenseEntry(string? description, int amount)
    {
        Description = description;
        Amount = amount;
        DateTime today = DateTime.Now;
        Created = today;
        Updated = today;
    }

    public virtual ExpenseEntry UpdateTo(ExpenseEntry entry)
    {
        Assert.IsNull(entry, "Unable to update expense entry. Null value detected");
        ExpenseEntry updatedEntry = new ExpenseEntry(entry.Description, entry.Amount);
        updatedEntry.Updated = DateTime.Now;

        return updatedEntry;
    }
}
