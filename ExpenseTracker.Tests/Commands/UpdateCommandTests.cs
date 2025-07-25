using ExpenseTracker.Library.Commands;
using ExpenseTracker.Library.Models;

namespace ExpenseTracker.Tests.Commands;

public class UpdateCommandTests
{
    [Theory]
    [InlineData(1, "")]
    [InlineData(-1, "test description")]
    public void CanExeucte_ValidData_ShouldPass(int testAmount, string testDescription)
    {
        // arrange
        UserInput testUserInput = new UserInput();
        testUserInput.Id = 1;
        testUserInput.Amount = testAmount;
        testUserInput.Description = testDescription;

        BaseCommand testInstance = new UpdateCommand();

        // action
        bool actual = testInstance.CanExecute(testUserInput);

        // assert
        Assert.True(actual);
    }

}
