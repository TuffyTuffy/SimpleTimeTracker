using SimpleTimeTracker.Providers;

namespace SimpleTimeTracker
{
    public static class GlobalFactory
    {
        public static IConfigProvider ConfigProvider
        {
            get
            {
                return new ConfigProvider();
            }
        }

        public static ISessionLogProvider SessionLogProvider
        {
            get
            {
                return new SessionLogProvider(ConfigProvider);
            }
        }
    }
}