using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AutoShutdown.Config
{
    public class Config
    {
        public string Password { get; set; } = "0000";
        public int ShutdownMinute { get; set; }

        private static string _configFilePath = "config.json";

        public void Save()
        {
            var json = JsonConvert.SerializeObject(new { ShutdownMinute });
            File.WriteAllText(_configFilePath, json);
        }

        public void Load()
        {
            int defaultMinute = 10;
            int value;

            if (File.Exists(_configFilePath))
            {
                var json = File.ReadAllText(_configFilePath);
                try
                {
                    var configData = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);

                    if (!configData.TryGetValue("ShutdownMinute", out value))
                    {
                        value = defaultMinute;
                    }
                }
                catch (Exception e)
                {
                    value = defaultMinute;
                }
            }
            else
            {
                value = defaultMinute;
            }

            ShutdownMinute = value;
            this.Save();
        }
    }
}