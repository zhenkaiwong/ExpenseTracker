namespace ExpenseTracker.Library.Extensions;

public static class DateTimeExtension
{
    public static string ToDatabaseString(this DateTime dateTime)
    {
        return dateTime.ToString("d");
    }
}
