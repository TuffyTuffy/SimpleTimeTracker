using SimpleTimeTracker.Entities;

namespace SimpleTimeTracker.Providers
{
    public interface ISessionLogProvider
    {
        void Log(SessionInfo session);
    }
}