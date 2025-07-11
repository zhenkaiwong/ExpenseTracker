using ExpenseTracker.Library.Mappers;

namespace ExpenseTracker.Tests.Mappers;

public class PorgramArgsMapperTests
{
    [Theory]
    [InlineData("")]
    [InlineData("add", "--description")]
    public void MapFromProgramArgs_InvalidArgs_ThrowsArgumentException(params string[] args)
    {
        Action action = () =>
        {
            var userInput = ProgramArgsMapper.MapFromProgramArgs(args);
        };
        Assert.Throws<ArgumentException>(action);
    }
}
