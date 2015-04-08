using System.Collections.Generic;
using SimpleTimeTracker.Entities;

namespace SimpleTimeTracker.Providers
{
    public interface IConfigProvider
    {
        IList<LabelInfo> GetLabels();
        LogInfo GetLogInfo();
    }
}