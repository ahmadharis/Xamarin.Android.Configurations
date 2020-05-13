using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;


namespace Service
{
    public class ConfigurationManager
    {
        public ConfigurationManager()
        {
        }

        public ConfigVM Read()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Service.Config.json";
            string jsonFile = "";

             using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
             {
                 jsonFile = reader.ReadToEnd(); //Make string equal to full file
             }

            var configs = JsonConvert.DeserializeObject<ConfigVM>(jsonFile);

            return configs;

        }
    }

    public class ConfigVM
    {
        public string Environment { get; set; }
        public string EndPointURL { get; set; }
        public string Secret { get; set; }
    }
}
