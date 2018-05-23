namespace ConsoleApp.Application
{
    using ConsoleApp.Services;
    using HelloWorldInfrastructure.Services;
    public class HelloWorldConsoleApp : IHelloWorldConsoleApp
    {
        //     The Hello World Web Service
        private readonly IHelloWorldWebService helloWorldWebService;
        
        private readonly ILogger logger;
        
        public HelloWorldConsoleApp(IHelloWorldWebService helloWorldWebService, ILogger logger)
        {
            this.helloWorldWebService = helloWorldWebService;
            this.logger = logger;
        }
        
        public void Run(string[] arguments)
        {
            var todaysData = this.helloWorldWebService.GetTodaysData();

            // Write "Hello World" to the console
            this.logger.Info(todaysData != null ? todaysData.Data : "No data was found!", null);
        }
    }
}