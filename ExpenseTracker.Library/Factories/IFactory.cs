namespace ExpenseTracker.Library.Factories;

public interface IFactory<TValue, TInstance>
{
    TInstance createInstance(string value);
}
