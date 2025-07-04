using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Validators;

public abstract class BaseValidator<TValue>
{
    public ValidationResult Validate(TValue value)
    {
        ValidationResult result = DoValidate(value);
        return result.Success ? Success() : Fail(result.Error);
    }
    protected abstract ValidationResult DoValidate(TValue value);
    private ValidationResult Success()
    {
        return new ValidationResult(true, string.Empty);
    }
    private ValidationResult Fail(string message)
    {
        return new ValidationResult(false, $"Validation failed. {message}");
    }
}
