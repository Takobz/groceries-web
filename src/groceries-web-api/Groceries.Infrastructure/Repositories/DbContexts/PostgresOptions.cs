namespace Groceries.Infrastructure.Repositories.DbContexts
{
    public class PostgresOptions
    {
        public const string PostgresOption = "Postgres";

        public string Host { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
    }
}