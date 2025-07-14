using Microsoft.Extensions.Configuration;

namespace ExpenseTracker.Library.Services;

public class ConfigurationService
{
    private const string CONFIGURATION_FILENAME = "appsettings.json";
    public static string GetDatabaseConnectionString()
    {
        IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile(CONFIGURATION_FILENAME);
        var config = configBuilder.Build();
        string? connectionString = config.GetConnectionString("database");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ApplicationException($"Invalid database connection string in {CONFIGURATION_FILENAME}");
        }

        return connectionString;
    }
}
