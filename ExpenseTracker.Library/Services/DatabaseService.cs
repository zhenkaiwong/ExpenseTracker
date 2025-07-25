using ExpenseTracker.Library.Mappers;
using ExpenseTracker.Library.Models;

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
