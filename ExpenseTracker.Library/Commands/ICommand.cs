using ExpenseTracker.Library.Models;

namespace ExpenseTracker.Library.Commands;

public interface ICommand
{
    void Execute(UserInput userInput);
    bool CanExecute(UserInput userInput);
}
