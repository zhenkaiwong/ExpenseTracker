using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;

namespace ExpenseTracker.Library.Mappers;

public static class ProgramArgsMapper
{
    public static UserInput MapFromProgramArgs(string[] args)
    {
        Assert.IsProgramArgsValid(args);

        UserInput userInput = new();
        string[] args2 = StripCommandFromArgs(args);
        for (int i = 0; i < args2.Length; i += 2)
        {
            string param = args2[i];
            string value = args2[i + 1];
            AddValueToUserInput(param, value, ref userInput);
        }

        return userInput;
    }

    private static string[] StripCommandFromArgs(string[] args)
    {
        // assume first element in args will always be the command
        return args.Skip(1).ToArray();
    }

    private static void AddValueToUserInput(string param, string value, ref UserInput userInput)
    {
        switch (param)
        {
            case Constants.Parameters.ID:
                int id = Convert.ToInt32(value);
                userInput.Id = id;
                break;
            case Constants.Parameters.AMOUNT:
                int amount = Convert.ToInt32(value);
                if (amount < 0)
                {
                    throw new ArgumentException($"Invalid amount input. Value for {Constants.Parameters.AMOUNT} should not be negative");
                }
                userInput.Amount = amount;
                break;
            case Constants.Parameters.DESCRIPTION:
                userInput.Description = value;
                break;
            case Constants.Parameters.MONTH:
                int month = Convert.ToInt32(value);
                if (month <= 0 || month > 12)
                {
                    throw new ArgumentException($"Invalid month input: \"{month}\". Value for {Constants.Parameters.MONTH} parameter should range from 1 to 12");
                }
                userInput.Month = month;
                break;
            default:
                throw new ArgumentException($"Invalid parameter: {param}");
        }
    }
}
