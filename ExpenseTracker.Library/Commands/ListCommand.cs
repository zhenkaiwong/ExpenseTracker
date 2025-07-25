using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Services;
using ExpenseTracker.Library.Utils;
using ExpenseTracker.Library.Validators;

namespace ExpenseTracker.Library.Commands;

public class ListCommand : BaseCommand
{
    public override bool CanExecute(UserInput userInput)
    {
        EmptyUserInputValidator validator = new();
        ValidationResult result = validator.Validate(userInput);
        return result.Success;
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