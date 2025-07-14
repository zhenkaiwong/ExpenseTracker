using ExpenseTracker.Library.Models;

namespace ExpenseTracker.Library.Services;

public class DatabaseService
{
    private readonly string FILE_NAME = ConfigurationService.GetDatabaseConnectionString();

    public void Insert(ExpenseEntry entry)
    {
        string data = $"{entry.Id};{entry.Description};{entry.Amount};{entry.Created};{entry.Updated}";
        using (StreamWriter sw = File.AppendText(FILE_NAME))
        {
            sw.WriteLine(data);
        }
    }
}
