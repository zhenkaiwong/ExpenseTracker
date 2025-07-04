namespace ExpenseTracker.Library.Factories;

public interface IFactory<TValue, TInstance>
{
    TInstance CreateInstance(TValue value);
    bool ContainsEntry(TValue value);
}
