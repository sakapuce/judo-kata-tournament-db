namespace JudoKataTournamentDB
{
    static class Logger
    {
        public delegate void LogEvent(LogEventArgs a);
        public static event LogEvent NewLogEvent;

        public static void Log(string text, LogLevel level)
        {
            if (NewLogEvent != null)
            {
                NewLogEvent(new LogEventArgs(text,level));
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
