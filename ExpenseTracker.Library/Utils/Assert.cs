using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Validators;

namespace ExpenseTracker.Library.Utils;

public class Assert
{
    public static void IsAmountInRange(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Amount shouldn't be 0 or lower");
        }
    }

    public static void IsStringNullOrEmpty(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException(value);
        }
    }

    public static void IsProgramArgsValid(string[] args)
    {
        ProgramArgsValidator validator = new();
        ValidationResult result = validator.Validate(args);
        if (!result.Success)
        {
            throw new ArgumentException($"Invalid program args. Message: {result.Error}");
        }
    }

    public static void IsParameterValid(string parameter)
    {
        switch (parameter)
        {
            case Constants.Parameters.AMOUNT:
            case Constants.Parameters.MONTH:
            case Constants.Parameters.DESCRIPTION:
            case Constants.Parameters.ID:
                return;
            default:
                throw new ArgumentException($"Invalid parameter: ${parameter}");
        }
    }

    public static void IsNull(object value, string? errorMessage)
    {
        if (value is null)
        {
            string error = errorMessage is null ? "Null vavalue detected" : errorMessage;
            throw new ArgumentException(error);
        }
    }
}
