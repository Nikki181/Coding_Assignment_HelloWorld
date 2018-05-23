
namespace HelloWorldInfrastructure.Services
{
    using System.Configuration;
    using HelloWorldInfrastructure.FrameworkWrappers;
    using HelloWorldInfrastructure.Mappers;
    using HelloWorldInfrastructure.Models;
    using HelloWorldInfrastructure.Resources;

    //     Data service for manipulating Hello World data
    
    public class HelloWorldDataService : IDataService
    {
        private readonly IAppSettings appSettings;
private readonly IDateTime dateTimeWrapper;
        private readonly IFileIOService fileIOService;
        private readonly IHelloWorldMapper helloWorldMapper;
        public HelloWorldDataService(
            IAppSettings appSettings,
            IDateTime dateTimeWrapper,
            IFileIOService fileIOService,
            IHelloWorldMapper helloWorldMapper)
        {
            this.appSettings = appSettings;
            this.dateTimeWrapper = dateTimeWrapper;
            this.fileIOService = fileIOService;
            this.helloWorldMapper = helloWorldMapper;
        }
        public TodaysData GetTodaysData()
        {
            var filePath = this.appSettings.Get(AppSettingsKeys.TodayDataFileKey);

            if (string.IsNullOrEmpty(filePath))
            {
                throw new SettingsPropertyNotFoundException(
                    ErrorCodes.TodaysDataFileSettingsKeyError, 
                    new SettingsPropertyNotFoundException("The TodayDataFile settings key was not found or had no value."));
            }

            var rawData = this.fileIOService.ReadFile(filePath);
            rawData += " as of " + this.dateTimeWrapper.Now().ToString("F");

            var todaysData = this.helloWorldMapper.StringToTodaysData(rawData);

            return todaysData;
        }
    }
}