using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Validators;

namespace ExpenseTracker.Tests.Validators;

public class EmptyUserInputValidatorTests
{
    [Fact]
    public void Validate_EmptyUserInput_SuccessValidation()
    {
        // arrange
        EmptyUserInputValidator testInstance = new();
        UserInput testData = new();

        // action
        ValidationResult actual = testInstance.Validate(testData);

        // assert
        Assert.True(actual.Success);
    }

    public static IEnumerable<object[]> GenerateTestData()
    {
        return new List<object[]>()
        {
            new object[] { new UserInput {Id = 1} },
            new object[] { new UserInput {Amount = 1} },
            new object[] { new UserInput {Month = 1} },
            new object[] { new UserInput {Description = "Lunch"} },
        };
    }

    [Theory]
    [MemberData(nameof(GenerateTestData))]
    public void Validate_NonEmptyUserInput_FailValidation(UserInput testData)
    {
        // arrange
        EmptyUserInputValidator testInstance = new();

        // action
        ValidationResult actual = testInstance.Validate(testData);

        // assert
        Assert.False(actual.Success);
    }

}
