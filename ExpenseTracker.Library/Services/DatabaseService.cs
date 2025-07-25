using ExpenseTracker.Library.Mappers;
using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Services;

public class DatabaseService
{
    private readonly string FILE_NAME = ConfigurationService.GetDatabaseConnectionString();

    private int GetNewRecordId()
    {
        return GetAllRecords().Count() + 1;
    }

    private string[] GetAllRecords()
    {
        if (!File.Exists(FILE_NAME))
        {
            return Array.Empty<string>();
        }
        return File.ReadAllLines(FILE_NAME);
    }

    public IEnumerable<ExpenseEntry> GetAll()
    {
        string[] records = GetAllRecords();
        return ExpenseEntryMapper.MapToExpenseEntries(records);
    }

    public void Insert(ExpenseEntry entry)
    {
        DateTime now = DateTime.Now;
        entry.Created = now;
        entry.Updated = now;
        entry.Id = GetNewRecordId();

        string data = ExpenseEntryMapper.MapToRawString(entry);

        File.AppendAllText(FILE_NAME, data + Environment.NewLine);
    }

    private ExpenseEntry? FindByIdFromEntries(List<ExpenseEntry> entries, int id)
    {
        try
        {
            return entries.First(entry => entry.Id == id);
        }
        catch
        {
            return null;
        }
    }

    private T TryUpdate<T>(Action<T> assertAction, T currentValue, T newValue)
    {
        try
        {
            assertAction(newValue);
            return newValue;
        }
        catch
        {
            return currentValue;
        }
    }

    public void Update(ExpenseEntry entry)
    {
        List<ExpenseEntry> dbEntries = GetAll().ToList();
        ExpenseEntry? targetDbEntry = FindByIdFromEntries(dbEntries, entry.Id);

        if (targetDbEntry is null)
        {
            throw new ArgumentException($"Unable to find expense with id: {entry.Id}");
        }

        targetDbEntry.Description = TryUpdate(Assert.IsStringNullOrEmpty, targetDbEntry.Description ?? "", entry.Description ?? "");
        targetDbEntry.Amount = TryUpdate(Assert.IsAmountInRange, targetDbEntry.Amount, entry.Amount);
        targetDbEntry.Updated = DateTime.Now;

        IEnumerable<string> data = ExpenseEntryMapper.MapToRawStringList(dbEntries);
        File.WriteAllLines(FILE_NAME, data);

    }

    public void Delete(ExpenseEntry entry)
    {
        IEnumerable<ExpenseEntry> entries = GetAll();
        if (!entries.Any(dbEntry => dbEntry.Id == entry.Id))
        {
            throw new KeyNotFoundException($"Unable to find entry with id {entry.Id}");
        }

        IEnumerable<ExpenseEntry> updatedEntries = entries.Where(dbEntry => dbEntry.Id != entry.Id);
        IEnumerable<string> data = ExpenseEntryMapper.MapToRawStringList(updatedEntries);

        File.WriteAllLines(FILE_NAME, data);
    }
}
