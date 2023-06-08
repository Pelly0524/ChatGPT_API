using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ChatGPT_API
{
    internal static class ConfigManager
    {
        private static IConfiguration _configuration;

        static ConfigManager()
        {
            _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        }

        public static string GetAppSetting(AppSetting setting)
        {
            string value = _configuration.GetSection("AppSettings")[setting.ToString()] ?? "";
            return value;
        }

        public enum AppSetting
        {
            ChatGPT_API_Key,
            ChatGPT_API_Url,
            ChatGPT_SystemMessage_Default,  
        }
    }
}
