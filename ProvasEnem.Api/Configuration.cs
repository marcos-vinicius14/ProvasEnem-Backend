namespace ProvasEnem.Api;

public class Configuration
{
    public string ConnectionString { get; } =
        new ConfigurationBuilder().Build().GetConnectionString("DefaultConnection")
        ?? string.Empty;
}