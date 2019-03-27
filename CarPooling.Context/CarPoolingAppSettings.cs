using Microsoft.Extensions.Configuration;

namespace CarPooling.Context
{
    public static class CarPoolingAppSettings
    {
        public static IConfigurationRoot ConfigurationRoot { get; set; }
        public static void Create()
        {
            var configBuilder = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true);
            ConfigurationRoot = configBuilder.Build();
        }
    }
}
