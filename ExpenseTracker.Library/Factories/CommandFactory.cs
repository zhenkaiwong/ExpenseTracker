using ExpenseTracker.Library.Commands;

namespace ExpenseTracker.Library.Factories;

public class CommandFactory : IFactory<string, BaseCommand>
{
    private Dictionary<string, BaseCommand> _commandEntries;
    public CommandFactory()
    {
        _commandEntries = new();

        _commandEntries.Add(Constants.Commands.ADD_COMMAND, new AddCommand());
        _commandEntries.Add(Constants.Commands.LIST_COMMAND, new ListCommand());
        _commandEntries.Add(Constants.Commands.SUMMARY_COMMAND, new SummaryCommand());
    }

    public bool ContainsEntry(string value)
    {
        return _commandEntries.ContainsKey(value);
    }

    public BaseCommand CreateInstance(string key)
    {
        if (!_commandEntries.ContainsKey(key))
        {
            throw new ArgumentException($"Unable to find command using key: {key}");
        }

        return _commandEntries[key];
    }

    public bool TryCreateInstance(string key, out BaseCommand? command)
    {
        try
        {
            command = CreateInstance(key);
            return true;
        }
        catch (ArgumentException)
        {
            command = null;
            return false;
        }
    }
}
