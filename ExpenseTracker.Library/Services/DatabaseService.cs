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

        using (StreamWriter sw = File.AppendText(FILE_NAME))
        {
            sw.WriteLine(data);
        }
    }
}
