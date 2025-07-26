using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Services;
using ExpenseTracker.Library.Utils;
using ExpenseTracker.Library.Validators;

namespace ExpenseTracker.Library.Commands;

public class SummaryCommand : BaseCommand
{
    private bool ValidateMonthInput(int month)
    {
        try
        {
            Assert.IsNumberInRange(month, 1, 12);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public override bool CanExecute(UserInput userInput)
    {
        EmptyUserInputValidator validator = new();
        ValidationResult emptyUserInputResult = validator.Validate(userInput);
        bool monthValid = ValidateMonthInput(userInput.Month);
        return emptyUserInputResult.Success || monthValid;
    }

    protected override void DoExecute(UserInput userInput)
    {
        bool monthValid = ValidateMonthInput(userInput.Month);
        DatabaseService dbService = new DatabaseService();
        IEnumerable<ExpenseEntry> entries = monthValid ? dbService.GetAllByMonth(userInput.Month) : dbService.GetAll();
        Log.Info($"Total expenses: ${GetTotalAmount(entries)}");
    }

    private int GetTotalAmount(IEnumerable<ExpenseEntry> entries)
    {
        return entries.Sum(entry => entry.Amount);
    }
}
