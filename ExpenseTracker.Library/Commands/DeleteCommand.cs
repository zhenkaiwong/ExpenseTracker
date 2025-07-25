using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Services;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Commands;

public class DeleteCommand : BaseCommand
{
    protected override bool CanExecute(UserInput userInput)
    {
        try
        {
            Assert.IsIdValid(userInput.Id);
            return true;
        }
        catch (ArgumentOutOfRangeException ex)
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
            Id = userInput.Id
        };
        dbService.Delete(entry);
    }
}
