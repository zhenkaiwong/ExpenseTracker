using ExpenseTracker.Library.Models;

namespace ExpenseTracker.Library.Validators;

public class ProgramArgsValidator : BaseValidator<string[]>
{
    protected override ValidationResult DoValidate(string[] args)
    {
        if (ValidForParameterlessCommand(args))
        {
            return new ValidationResult(true);
        }

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

    private bool ValidForParameterlessCommand(string[] args)
    {
        if (args.Length > 1)
        {
            return false;
        }

        string command = args[0];

        switch (command)
        {
            case Constants.Commands.LIST_COMMAND:
            case Constants.Commands.SUMMARY_COMMAND:
                return true;
            default:
                return false;
        }
    }
}
