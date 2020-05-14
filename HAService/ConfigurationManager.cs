using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;


namespace HA.Service
{
    /// <summary>
    /// Configuration Manager
    /// </summary>
    public class ConfigurationManager
    {
        /// <summary>
        /// holds a reference to the single created instance, if any.
        /// </summary>
        private static readonly Lazy<ConfigurationManager> lazy = new Lazy<ConfigurationManager>(() => new ConfigurationManager());

        /// <summary>
        /// Getting reference to the single created instance, creating one if necessary.
        /// </summary>
        public static ConfigurationManager Instance { get; } = lazy.Value;

        public Configuration JSONConfiguration { get; set; }
        public ConfigurationManager()
        {
            JSONConfiguration = this.Read();
        }

        public Configuration Read()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = "HA.Service.Config.json";
            string jsonFile = "";

             using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
             {
                 jsonFile = reader.ReadToEnd(); //Make string equal to full file
             }

            var configs = JsonConvert.DeserializeObject<Configuration>(jsonFile);

            return configs;
        }
    }

    public class Configuration
    {
        public string Environment { get; set; }
        public string APIEndPoint { get; set; }
        public string APIKey { get; set; }
    }
}


