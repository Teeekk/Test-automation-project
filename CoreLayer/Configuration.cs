
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace AutomationProjectTest.CoreLayer
{
    public static class Configuration
    {
        private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true,reloadOnChange: true)
            .Build();
        
        public static string BaseUrl => _configuration["BaseUrl"] ??  "https://www.saucedemo.com";
        public static BrowserType Browser =>
        Enum.TryParse<BrowserType>(_configuration["Browser"], true, out var b) ?  b : BrowserType.Chrome;

        public static int MaxImplicitWaitSeconds =>
            int.TryParse(_configuration["MaxImplicitWaitSeconds"], out var v) ? v : 5;
        public static int PageLoadTimeoutSeconds =>
            int.TryParse(_configuration["PageLoadTimeoutSeconds"], out var t) ? t : 30;
    }
}