using iTechArt.Common.Interface;
using Serilog;
using SerLog = Serilog.Core;

namespace iTechArt.Common
{
    public class Logger : ILog
    {
        static LoggerConfiguration _configuration = new LoggerConfiguration();
        public static LogLevel logLevel = LogLevel.Debug;
        public SerLog.Logger SerLogger;

        public Logger(LoggerConfiguration configuration)
        {
            _configuration = configuration;
            SerLogger = _configuration.CreateLogger();
        }

        public void Log(object message, LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    _configuration.WriteTo.File("Logs\\log.txt", Serilog.Events.LogEventLevel.Debug);
                    break;
                case LogLevel.Error:
                    _configuration.WriteTo.File("Logs\\log.txt", Serilog.Events.LogEventLevel.Error);
                    break;
                case LogLevel.Fatal:
                    _configuration.WriteTo.File("Logs\\log.txt", Serilog.Events.LogEventLevel.Fatal);
                    break;
                case LogLevel.Info:
                    _configuration.WriteTo.File("Logs\\log.txt", Serilog.Events.LogEventLevel.Information);
                    break;
                case LogLevel.Warning:
                    _configuration.WriteTo.File("Logs\\log.txt", Serilog.Events.LogEventLevel.Warning);
                    break;
            }
        }
    }
}
