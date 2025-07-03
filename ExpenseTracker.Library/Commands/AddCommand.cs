using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Commands;

public class AddCommand : ICommand
{
    public bool CanExecute(UserInput userInput)
    {
        try
        {
            Assert.IsAmountInRange(userInput.Amount);
            Assert.IsStringNull(userInput.Description);

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }

    public void Execute(UserInput userInput)
    {
        string? description = userInput.Description;
        int amount = userInput.Amount;

        Log.Info($"Executed add command.\nDescription:\t{description ?? "Invalid input"}\nAmount:\t{amount}");
    }
}
