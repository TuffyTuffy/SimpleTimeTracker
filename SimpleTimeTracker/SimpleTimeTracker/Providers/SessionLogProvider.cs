using System;
using System.IO;
using SimpleTimeTracker.Entities;

namespace SimpleTimeTracker.Providers
{
    public class SessionLogProvider : ISessionLogProvider
    {
        private readonly string _logFilePath;

        public SessionLogProvider(IConfigProvider cfgProvider)
        {
            var logPath = cfgProvider.GetLogInfo().LogPath;
            if (string.IsNullOrEmpty(logPath) || !File.Exists(logPath))
            {
                //Use the default
                logPath = Environment.CurrentDirectory;
            }

            _logFilePath = Path.Combine(logPath, "Log.csv");
        }

        public void Log(SessionInfo session)
        {
            if (session == null) throw new ArgumentNullException("session");

            using (var sw = new StreamWriter(_logFilePath, true))
            {
                sw.WriteLine(string.Format(string.Format("{0},{1}h:{2}m:{3}s,{4},{5},\"{6}\"", 
                    session.StartDate, 
                    session.Duration.Hours, 
                    session.Duration.Minutes, 
                    session.Duration.Seconds, 
                    session.Interruptions, session.Label, session.Comment.Replace("\"","\"\""))));
            }
        }
    }
}