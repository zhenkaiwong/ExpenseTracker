using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Validators;

public class EmptyUserInputValidator : BaseValidator<UserInput>
{
    // this validator is used to determine if UserInput is having default value 
    protected override ValidationResult DoValidate(UserInput value)
    {
        bool idValid = TryExecute(() => Assert.IsIdValid(value.Id));
        bool descriptionValid = TryExecute(() => Assert.IsStringNullOrEmpty(value.Description));
        bool amountValid = TryExecute(() => Assert.IsAmountInRange(value.Amount));
        bool monthValid = TryExecute(() => Assert.IsNumberInRange(value.Month, 1, 12));

        bool[] results = [idValid, descriptionValid, amountValid, monthValid];
        bool isEmpty = results.All(result => result == false);

        return isEmpty ? new ValidationResult(true) : new ValidationResult(false, "UserInput isn't empty");
    }

    private bool TryExecute(Action action)
    {
        try
        {
            action();
        }
        catch (ArgumentException)
        {
            return false;
        }

        return true;
    }
}
