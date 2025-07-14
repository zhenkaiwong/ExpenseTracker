using ExpenseTracker.Library.Mappers;
using ExpenseTracker.Library.Models;

namespace ExpenseTracker.Tests.Mappers;

public class ExpenseEntryMapperTests
{
    [Theory]
    [InlineData("")]
    [InlineData("1,2,3")]
    [InlineData("-1;Lunch;20;2025-07-14T19:18:37.7478120+08:00;2025-07-14T19:18:37.7478120+08:00")]
    [InlineData("1;;20;2025-07-14T19:18:37.7478120+08:00;2025-07-14T19:18:37.7478120+08:00")]
    [InlineData("1;Lunch;-1;2025-07-14T19:18:37.7478120+08:00;2025-07-14T19:18:37.7478120+08:00")]
    public void MapToExpenseEntry_InvalidData_ThrowsArgumentException(string testData)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            ExpenseEntryMapper.MapToExpenseEntry(testData);
        });
    }

    [Theory]
    [InlineData("1;Lunch;20;2025-07-33T19:18:37.7478120+08:00;2025-07-14T19:18:37.7478120+08:00")]
    [InlineData("1;Lunch;20;2025-07-14T19:18:37.7478120+08:00;2025-07-33T19:18:37.7478120+08:00")]
    public void MapToExpenseEntry_InvalidDate_ThrowsArgumentException(string testData)
    {
        Assert.Throws<FormatException>(() =>
        {
            ExpenseEntryMapper.MapToExpenseEntry(testData);
        });
    }

    public static IEnumerable<object[]> GetInvalidExpenseEntries()
    {
        return new List<object[]>()
        {
            new object[] {
                new ExpenseEntry() {
                    Id = -1,
                    Amount = 1,
                    Description = "Lunch",
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                }
            },
            new object[] {
                new ExpenseEntry() {
                    Id = 1,
                    Amount = -1,
                    Description = "Lunch",
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                }
            },
            new object[] {
                new ExpenseEntry() {
                    Id = 1,
                    Amount = 1,
                    Description = string.Empty,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                }
            },
            new object[] {
                new ExpenseEntry() {
                    Id = 1,
                    Amount = 1,
                    Description = "Lunch",
                    Created = DateTime.Now,
                }
            },
            new object[] {
                new ExpenseEntry() {
                    Id = 1,
                    Amount = 1,
                    Description = "Lunch",
                    Updated = DateTime.Now
                }
            },
        };
    }

    [Theory]
    [MemberData(nameof(GetInvalidExpenseEntries))]
    public void MapToRawString_InvalidData_ThrowsArgumentException(ExpenseEntry entry)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            ExpenseEntryMapper.MapToRawString(entry);
        });
    }
}
