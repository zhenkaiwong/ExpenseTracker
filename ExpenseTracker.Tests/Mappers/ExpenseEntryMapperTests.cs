using ExpenseTracker.Library.Mappers;

namespace ExpenseTracker.Tests.Mappers;

public class ExpenseEntryMapperTests
{
    [Theory]
    [InlineData("")]
    [InlineData("1,2,3")]
    [InlineData("-1;Lunch;20;14/07/2025 3:43:55 PM;14/07/2025 3:43:55 PM")]
    [InlineData("0;;20;14/07/2025 3:43:55 PM;14/07/2025 3:43:55 PM")]
    [InlineData("0;Lunch;-1;14/07/2025 3:43:55 PM;14/07/2025 3:43:55 PM")]
    [InlineData("0;Lunch;10000;14/07/2025 3:43:55 PM;14/07/2025 3:43:55 PM")]
    public void MapToExpenseEntry_InvalidData_ThrowsArgumentException(string testData)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            ExpenseEntryMapper.MapToExpenseEntry(testData);
        });
    }

    [Theory]
    [InlineData("0;Lunch;20;32/07/2025 3:43:55 PM;14/07/2025 3:43:55 PM")]
    [InlineData("0;Lunch;20;14/07/2025 3:43:55 PM;32/07/2025 3:43:55 PM")]
    public void MapToExpenseEntry_InvalidDate_ThrowsArgumentException(string testData)
    {
        Assert.Throws<FormatException>(() =>
        {
            ExpenseEntryMapper.MapToExpenseEntry(testData);
        });
    }

    [Theory]
    public void MapToRawString_InvalidData_ThrowsArgumentException(int id, string description, int amount, DateTime created, DateTime updated)
    {

    }
}
