using System;
using System.IO;

namespace JudoKataTournamentDB
{
    static class Logger
    {
        public delegate void LogEvent(LogEventArgs a);
        public static event LogEvent NewLogEvent;
        public static StreamWriter _logStreamWriter;

        static Logger()
        {
            _logStreamWriter = new StreamWriter("log.txt", true);
            _logStreamWriter.AutoFlush = true;
            Log("New Logger Instance Created",LogLevel.Info);
        }

        public static void Log(string text, LogLevel level)
        {
            string logMessage = string.Format("{0} - {1}: {2}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), level, text);
            _logStreamWriter.WriteLine(logMessage);
            if (NewLogEvent != null)
            {
                NewLogEvent(new LogEventArgs(logMessage, level));
            }
        }

        public class LogEventArgs
        {
            public string Text;
            public LogLevel Level;
            public LogEventArgs(string text, LogLevel level)
            {
                Text = text;
                Level = level;
            }
        }

        public enum LogLevel
        {
            Info=1,
            Warning=2,
            Error=4,
        }
    }
}
