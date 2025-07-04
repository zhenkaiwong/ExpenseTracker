using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;
using ExpenseTracker.Library.Validators;

namespace ExpenseTracker.Library.Mappers;

public class ProgramArgsMapper
{
    public static UserInput MapFromProgramArgs(string[] args)
    {
        Assert.IsProgramArgsValid(args);

        UserInput userInput = new();
        return userInput;
    }
}
