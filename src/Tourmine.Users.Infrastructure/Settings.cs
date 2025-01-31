namespace Tourmine.Users.Infrastructure
{
    public abstract class Settings
    {
        public static string ConnectionString = "Host=roundhouse.proxy.rlwy.net;Port=52938;Username=postgres;Password=bJqzJtfRLNlnjUwOHAAhNDUagGsLETvi;Database=railway"
            ?? string.Empty;
    }
}
