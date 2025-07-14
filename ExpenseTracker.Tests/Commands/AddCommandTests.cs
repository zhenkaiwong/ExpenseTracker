using ExpenseTracker.Library.Commands;
using ExpenseTracker.Library.Models;

namespace ExpenseTracker.Tests.Commands;

public class AddCommandTests
{
    [Fact]
    public void Execute_InvalidData_ThrowsArgumentException()
    {
        UserInput testUserInput = new UserInput();
        testUserInput.Amount = 0;
        testUserInput.Description = string.Empty;

        BaseCommand testInstance = new AddCommand();

        Assert.Throws<ArgumentException>(() =>
        {
            testInstance.Execute(testUserInput);
        });
    }
}
