using iTechArt.Common.Interface;
using System.Collections.Generic;
using System.Linq;

namespace iTechArt.Common
{
    internal static class Log
    {
        public static readonly List<ILog> loggers = new List<ILog>();
        public static LogLevel logLevel = LogLevel.Debug;


        public static void  AddLog(ILog log)
        {
            if(loggers != null)
            {
                loggers.Add(log);
            }
        }

        public static void AddLog<T>() where T : ILog, new()
        {
            if(!loggers.OfType<T>().Any())
            {
                loggers.Add(new T());
            }
        }

        public static void RemoveLog(ILog log)
        {
            loggers.Remove(log);
        }

        public static void RemoveLog<T>() where T : ILog, new()
        {
            foreach(var log in loggers.OfType<T>().ToArray())
            {
                loggers.Remove(log);
            }
        }

        public static void Debug(object message, bool frameCount = false, object context = null)
        {
            if(logLevel < LogLevel.Debug)
            {
                return;
            }
            foreach(var log in loggers)
            {
                log.Log(message, LogLevel.Debug);
            }
        }

        public static void Info(object message, bool frameCount = false, object context = null)
        {
            if (logLevel < LogLevel.Info)
            {
                return;
            }
            foreach (var log in loggers)
            {
                log.Log(message, LogLevel.Info);
            }
        }

        public static void Warning(object message, bool frameCount = false, object context = null)
        {
            if (logLevel < LogLevel.Warning)
            {
                return;
            }
            foreach (var log in loggers)
            {
                log.Log(message, LogLevel.Warning);
            }
        }

        public static void Error(object message, bool frameCount = false, object context = null)
        {
            if (logLevel < LogLevel.Error)
            {
                return;
            }
            foreach (var log in loggers)
            {
                log.Log(message, LogLevel.Error);
            }
        }

        public static void Fatal(object message, bool frameCount = false, object context = null)
        {
            if (logLevel < LogLevel.Fatal)
            {
                return;
            }
            foreach (var log in loggers)
            {
                log.Log(message, LogLevel.Fatal);
            }
        }
    }
}
