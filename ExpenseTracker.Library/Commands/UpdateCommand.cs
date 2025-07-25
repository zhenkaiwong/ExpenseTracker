using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Services;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Commands;

public class UpdateCommand : BaseCommand
{
    private void Check<T>(Action<T> assertAction, T value, ref bool result)
    {
        try
        {
            assertAction(value);
            result = true;
        }
        catch
        {
            return;
        }
    }

    public override bool CanExecute(UserInput userInput)
    {
        try
        {
            Assert.IsIdValid(userInput.Id);
            bool sufficientInput = false;
            Check(Assert.IsAmountInRange, userInput.Amount, ref sufficientInput);
            Check(Assert.IsStringNullOrEmpty, userInput.Description, ref sufficientInput);

            if (!sufficientInput)
            {
                throw new ArgumentException($"Update command requires at least one user parameter");
            }

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
        ExpenseEntry entry = new()
        {
            Id = userInput.Id,
            Description = userInput.Description,
            Amount = userInput.Amount
        };

        DatabaseService dbService = new();
        dbService.Update(entry);
    }
}