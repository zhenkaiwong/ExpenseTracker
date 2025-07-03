using ExpenseTracker.Library.Models;

namespace ExpenseTracker.Library.Factories;

public class UserInputFactory : IFactory<string, UserInput>
{
    public UserInput createInstance(string consoleArgs)
    {
        throw new NotImplementedException();
    }
}

// example input
//  zhenkai@zhenkai-pc  ~  works  ExpenseTracker  ExpenseTracker.Console  master 
// ❯ ls
// bin  ExpenseTracker.Console.csproj  obj  Program.cs
//  zhenkai@zhenkai-pc  ~  works  ExpenseTracker  ExpenseTracker.Console  master 
// ❯ dotnet run add --description "Launch" --amount 20
// 0. add
// 1. --description
// 2. Launch
// 3. --amount
// 4. 20
//  zhenkai@zhenkai-pc  ~  works  ExpenseTracker  ExpenseTracker.Console  master 
// ❯ dotnet run summaryh --month 8
// 0. summaryh
// 1. --month
// 2. 8
//  zhenkai@zhenkai-pc  ~  works  ExpenseTracker  ExpenseTracker.Console  master 