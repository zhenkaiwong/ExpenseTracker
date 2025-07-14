using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Services;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Commands;

public class ListCommand : BaseCommand
{
    protected override bool CanExecute(UserInput userInput)
    {
        // this command can always be executed regardless user input
        // since it doesn't rely on any data from it
        return true;
    }

    protected override void DoExecute(UserInput userInput)
    {
        DatabaseService dbService = new DatabaseService();
        IEnumerable<ExpenseEntry> entries = dbService.GetAll();
        Log.Info("# ID\tDate\t\t\tDescription\t\tAmount");
        foreach (ExpenseEntry entry in entries)
        {
            Log.Info($"# {entry.Id}\t{entry.Updated,-10}\t{entry.Description,-20}\t{entry.Amount}");
        }
    }
}