using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Services;
using ExpenseTracker.Library.Utils;
using ExpenseTracker.Library.Validators;

namespace ExpenseTracker.Library.Commands;

public class SummaryCommand : BaseCommand
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
        Log.Info($"Total expenses: ${GetTotalAmount(entries)}");
    }

    private int GetTotalAmount(IEnumerable<ExpenseEntry> entries)
    {
        return entries.Sum(entry => entry.Amount);
    }
}
