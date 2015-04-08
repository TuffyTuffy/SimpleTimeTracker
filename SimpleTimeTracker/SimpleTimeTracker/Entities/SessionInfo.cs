using System;

namespace SimpleTimeTracker.Entities
{
    public class SessionInfo
    {
        public string Comment { get; set; }
        public string Label { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public int Interruptions { get; set; }
    }
}