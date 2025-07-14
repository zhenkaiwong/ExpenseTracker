using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Commands;

public class AddCommand : BaseCommand
{
    protected override bool CanExecute(UserInput userInput)
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
        string? description = userInput.Description;
        int amount = userInput.Amount;

        Log.Info($"Executed add command.\nDescription:\t{description ?? "Invalid input"}\nAmount:\t{amount}");
    }
}
