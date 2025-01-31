namespace Tourmine.Users.Infrastructure
{
    public abstract class Settings
    {
        public static string ConnectionString = Environment.GetEnvironmentVariable("tourmine-user-database") ?? string.Empty;
    }
}
