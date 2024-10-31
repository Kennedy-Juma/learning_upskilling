namespace ShareMemoriesHub.Interfaces
{
    public interface ILoggerUtil
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
