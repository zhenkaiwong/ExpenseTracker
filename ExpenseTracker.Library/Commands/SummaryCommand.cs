using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Validators;

namespace ExpenseTracker.Library.Commands;

public class SummaryCommand : BaseCommand
{
    protected override bool CanExecute(UserInput userInput)
    {
        EmptyUserInputValidator validator = new();
        ValidationResult result = validator.Validate(userInput);
        return result.Success;
    }

    protected override void DoExecute(UserInput userInput)
    {
        throw new NotImplementedException();
    }
}
