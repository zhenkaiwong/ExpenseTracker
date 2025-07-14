using ExpenseTracker.Library.Commands;
using ExpenseTracker.Library.Factories;
using ExpenseTracker.Library.Mappers;
using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;

Assert.IsProgramArgsValid(args);

string commandKey = args[0];
CommandFactory commandFactory = new CommandFactory();
UserInput userInput = ProgramArgsMapper.MapFromProgramArgs(args);
BaseCommand command = commandFactory.CreateInstance(commandKey);
command.Execute(userInput);
Console.WriteLine("Done");