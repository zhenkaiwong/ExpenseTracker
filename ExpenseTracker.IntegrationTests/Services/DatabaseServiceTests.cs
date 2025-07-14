using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Services;
using NUnit.Framework;

namespace ExpenseTracker.IntegrationTests.Services;

public class DatabaseServiceTests
{
    private readonly string TEST_DATA_FILENAME = ConfigurationService.GetDatabaseConnectionString();
    [SetUp]
    public void SetUp()
    {
        if (File.Exists(TEST_DATA_FILENAME))
        {
            File.Delete(TEST_DATA_FILENAME);
        }
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(TEST_DATA_FILENAME))
        {
            File.Delete(TEST_DATA_FILENAME);
        }
    }

    [Test]
    public void Insert_ValidData_ShouldInsertEntryIntoLastPosition()
    {
        // arrange
        ExpenseEntry expenseEntry = new()
        {
            Description = "Lunch",
            Amount = 20
        };

        DatabaseService testInstance = new();
        DateTime now = DateTime.Now;
        string expected = $"1;Lunch;20;{now};{now}";

        // action
        testInstance.Insert(expenseEntry);

        // assert
        string[] fileContent = File.ReadAllLines(TEST_DATA_FILENAME);
        string actual = fileContent.Last();
        Assert.That(actual, Is.EqualTo(expected));
    }
}
