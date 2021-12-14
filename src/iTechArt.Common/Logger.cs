using Serilog;
using Serilog.Events;
using System;

namespace iTechArt.Common
{
    public class Logger : ILog
    {
        private ILogger _logger;


        public Logger(ILogger logger)
        {
            _logger = logger;
        }
        

        public void Log(LogLevel logLevel, string message, Exception exception)
        {
            _logger.Write((LogEventLevel)logLevel, exception, message);
        }

        public void Log(LogLevel logLevel, string message)
        {
            _logger.Write((LogEventLevel)logLevel, message);
        }
    }
}
