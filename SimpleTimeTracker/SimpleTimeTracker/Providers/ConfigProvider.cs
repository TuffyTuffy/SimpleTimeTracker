using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using SimpleTimeTracker.Entities;

namespace SimpleTimeTracker.Providers
{
    public class ConfigProvider : IConfigProvider
    {
        private XDocument _doc;

        public ConfigProvider()
        {
            var configPath = Path.Combine(Environment.CurrentDirectory, "Config.xml");
            if (File.Exists(configPath))
            {

                _doc = XDocument.Load(configPath);
            }
            
        }

        public IList<LabelInfo> GetLabels()
        {
            return _doc.Descendants("Label").Select((element, index) => new LabelInfo { Value = element.Value, Name = string.Format("{0} - {1}", index + 1, element.Value) }).ToList();
        }

        public LogInfo GetLogInfo()
        {
            var logNode = _doc.Descendants("Log").Single();
            if (logNode == null)
                return new LogInfo();
            else
            {
                return new LogInfo {LogPath = logNode.Attribute("LogPath").Value};
            }
        }
    }
}
