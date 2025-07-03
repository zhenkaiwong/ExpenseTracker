using ExpenseTracker.Library.Commands;

namespace ExpenseTracker.Library.Factories;

public class CommandFactory : IFactory<string, ICommand>
{
    private Dictionary<string, ICommand> _commandEntries;
    public CommandFactory()
    {
        _commandEntries = new();

        _commandEntries.Add(Constants.Commands.ADD_COMMAND, new AddCommand());
    }

    public ICommand createInstance(string key)
    {
        if (!_commandEntries.ContainsKey(key))
        {
            throw new ArgumentException($"Unable to find command using key: {key}");
        }

        return _commandEntries[key];
    }
}
