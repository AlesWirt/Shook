﻿using System;

namespace iTechArt.Common
{
    public interface ILog
    {
        public void Log(LogLevel logLevel, string message);

        public void Log(LogLevel logLevel, Exception exception, string message);
    }
}