using Serilog;

namespace iTechArt.Common
{
    public class SerilogDecorator
    {
        public void Information(string message)
        {
            Log.Information(message);
        }
    }
}
