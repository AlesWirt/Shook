using Serilog;

namespace iTechArt.Common.Interface
{
    public interface ILog
    {
        public void Log(object message, LogLevel logLevel);
    }
}
