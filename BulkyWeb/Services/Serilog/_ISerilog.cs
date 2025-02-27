namespace BulkyWeb.Services.Serilog
{
    public interface _ISerilog
    {
        string UserAndHost();
        //string CurrentUser();
        void LogInformation(string message);
        void LogNoMessage();
        void LogWarning(string message);
        void LogError(string message);
        
    }
}
