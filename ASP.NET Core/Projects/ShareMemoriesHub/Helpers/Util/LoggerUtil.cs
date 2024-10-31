using NLog;
using ShareMemoriesHub.Interfaces;
using ILogger = NLog.ILogger;

namespace ShareMemoriesHub.Helpers.Util
{
    public class LoggerUtil : ILoggerUtil
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerUtil()
        {
        }
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
        public void LogError(string message)
        {
            logger.Error(message);
        }
        public void LogInfo(string message)
        {
            logger.Info(message);
        }
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
