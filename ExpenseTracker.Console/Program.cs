using ExpenseTracker.Library.Commands;
using ExpenseTracker.Library.Factories;
using ExpenseTracker.Library.Mappers;
using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;

Assert.IsProgramArgsValid(args);

string commandKey = args[0];
CommandFactory commandFactory = new CommandFactory();
if (!commandFactory.TryCreateInstance(commandKey, out var command) || command is null)
{
    Log.Error($"Unable to find handler for this command: {commandKey}");
    return;
}
UserInput userInput = ProgramArgsMapper.MapFromProgramArgs(args);
command.Execute(userInput);
Console.WriteLine("Done");