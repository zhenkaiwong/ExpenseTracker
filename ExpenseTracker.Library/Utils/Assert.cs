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

    public static void IsStringNull(string? value)
    {
        if (value is null)
        {
            throw new ArgumentException("String shouldn't be null");
        }
    }
}
