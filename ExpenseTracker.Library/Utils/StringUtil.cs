namespace ExpenseTracker.Library.Utils;

public class StringUtil
{
    public static string PrependString(string value, string prepend)
    {
        return $"{prepend}{value}";
    }
}
