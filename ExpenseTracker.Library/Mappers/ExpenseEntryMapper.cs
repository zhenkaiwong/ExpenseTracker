using ExpenseTracker.Library.Extensions;
using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Mappers;

public class ExpenseEntryMapper
{
    public static ExpenseEntry MapToExpenseEntry(string rawString)
    {
        Assert.IsStringNullOrEmpty(rawString);

        string[] items = rawString.Split(";");

        if (items.Count() != 5)
        {
            throw new ArgumentException($"Raw string must contains exact 5 items");
        }

        int id = Convert.ToInt32(items[0]);
        string description = items[1];
        int amount = Convert.ToInt32(items[2]);
        DateTime created = Convert.ToDateTime(items[3]);
        DateTime updated = Convert.ToDateTime(items[4]);

        Assert.IsNumberPositive(id);
        Assert.IsStringNullOrEmpty(description);
        Assert.IsAmountInRange(amount);

        return new ExpenseEntry()
        {
            Id = id,
            Description = description,
            Amount = amount,
            Created = created,
            Updated = updated
        };
    }

    public static IEnumerable<ExpenseEntry> MapToExpenseEntries(string[] rawStrings)
    {
        return rawStrings.Select(rawString => MapToExpenseEntry(rawString));
    }

    public static string MapToRawString(ExpenseEntry entry)
    {
        string test = DateTime.Now.ToString("o");
        Assert.IsNumberPositive(entry.Id);
        Assert.IsStringNullOrEmpty(entry.Description);
        Assert.IsAmountInRange(entry.Amount);
        Assert.IsDateTimeValid(entry.Created);
        Assert.IsDateTimeValid(entry.Updated);


        return $"{entry.Id};{entry.Description};{entry.Amount};{entry.Created.ToDatabaseString()};{entry.Updated.ToDatabaseString()}";
    }
}
