using ExpenseTracker.Library.Models;

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
        throw new NotImplementedException();
    }
}
