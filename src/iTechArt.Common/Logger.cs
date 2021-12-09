using iTechArt.Common.Interface;
using Serilog;
using System;
using SerLog = Serilog.Core;

namespace iTechArt.Common
{
    public class Logger : ILog
    {
        private ILogger _logger;

        
        public Logger()
        {
            _logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        public Logger(string path)
        {
            LogToFile(path);
        }

        private void LogToFile(string path)
        {
            _logger = new LoggerConfiguration().WriteTo.File(path).CreateLogger();
        }

        public void Log(LogLevel logLevel, string message, Exception exception = null)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    _logger.Debug(message);
                    break;
                case LogLevel.Info:
                    _logger.Information(message);
                    break;
                case LogLevel.Warning:
                    _logger.Warning(message);
                    break;
                case LogLevel.Error:
                    _logger.Error(message, exception);
                    break;
                case LogLevel.Fatal:
                    _logger.Fatal(message, exception);
                    break;
            }
        }
    }
}
