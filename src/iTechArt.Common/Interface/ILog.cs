using System;
using System.Collections.Generic;
using System.Text;

namespace iTechArt.Common.Interface
{
    internal interface ILog
    {
        void Log(object message, LogLevel logLevel, bool frameCount = false, object context = null);

    }
}
