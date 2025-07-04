namespace ExpenseTracker.Library.Models;

public class ValidationResult
{
    public bool Success { get; private set; }
    public string Error { get; private set; }
    public ValidationResult(bool success, string error)
    {
        Success = success;
        Error = error;
    }
    public ValidationResult(bool success)
    {
        Success = success;
        Error = string.Empty;
    }
}
