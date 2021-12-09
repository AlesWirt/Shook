using System;

namespace iTechArt.Common.Interface
{
    public interface ILog
    {
        public void Log(LogLevel logLevel, string message, Exception exception);
    }
}
