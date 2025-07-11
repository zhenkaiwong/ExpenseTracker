using ExpenseTracker.Library.Models;

namespace ExpenseTracker.Library.Validators;

public class ProgramArgsValidator : BaseValidator<string[]>
{
    protected override ValidationResult DoValidate(string[] args)
    {
        // args length must be odd number and larger than 1
        if (args.Length <= 1)
        {
            return new ValidationResult(false, "Program args should have at least 1 argument");
        }

        if (args.Length % 2 == 0)
        {
            return new ValidationResult(false, "Program args need more data");
        }

        return new ValidationResult(true);
    }
}
