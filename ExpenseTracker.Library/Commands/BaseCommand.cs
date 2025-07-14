using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Commands;

public abstract class BaseCommand
{
    public void Execute(UserInput userInput)
    {
        if (!CanExecute(userInput))
        {
            throw new ArgumentException($"{this} cannot handle the input");
        }
        DoExecute(userInput);
    }
    protected abstract bool CanExecute(UserInput userInput);
    protected abstract void DoExecute(UserInput userInput);
}
