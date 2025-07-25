using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Services;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Commands;

public class AddCommand : BaseCommand
{
    public override bool CanExecute(UserInput userInput)
    {
        try
        {
            Assert.IsAmountInRange(userInput.Amount);
            Assert.IsStringNullOrEmpty(userInput.Description);

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }

    protected override void DoExecute(UserInput userInput)
    {
        DatabaseService dbService = new DatabaseService();
        ExpenseEntry entry = new()
        {
            Description = userInput.Description,
            Amount = userInput.Amount
        };

        dbService.Insert(entry);
    }
}
