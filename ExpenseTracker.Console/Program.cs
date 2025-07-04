// we need 5 commands:
// 1. add --> input: description & amount
// 2. list
// 3. summary
// 4. delete
// 5. update --> input: description & amount

// we need to have a way to determine command,
// and whether or not the user provided the necessary input for the command


using ExpenseTracker.Library.Models;
using ExpenseTracker.Library.Utils;
using ExpenseTracker.Library.Validators;

Assert.IsProgramArgsValid(args);

string command = args[0];