using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServicesRegisterTool
{
    public class Config
    {
        public static Config Default { get; }
        static Config()
        {
            string configDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ServicesRegisterTool";
            if (!Directory.Exists(configDir)) Directory.CreateDirectory(configDir);
            string configFile = $"{configDir}\\config.json";
            if (File.Exists(configFile))
            {
                string jstr = File.ReadAllText(configFile);
                Default= JsonSerializer.Deserialize<Config>(jstr);
            }
            else
                Default = new Config();
        }
        public string LastServiceName { get; set; }
        public string LastServiceExe {  get; set; }
        public void Save()
        {
            string configDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ServicesRegisterTool";
            if (!Directory.Exists(configDir)) Directory.CreateDirectory(configDir);
            string configFile = $"{configDir}\\config.json";
            string jstr=JsonSerializer.Serialize(this);
            File.WriteAllText(configFile, jstr);
        }
    }
}
