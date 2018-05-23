
namespace HelloWorldInfrastructure.Services
{
    using System.Configuration;

    //     Service for application settings in a configuration file

    public class ConfigAppSettings : IAppSettings
    {
        public string Get(string name)
        {
            return ConfigurationManager.AppSettings.Get(name);
        }
    }
}