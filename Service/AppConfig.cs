using System;

namespace Service
{
    public class AppConfig
    {
        public AppConfig()
        {
            
            ConfigurationManager cfg = new ConfigurationManager();
            var a = cfg.Read();
            var c = a.EndPointURL;
            Hello = a.Secret;
        }

        public string Hello { get; set; }
    }

   
}
