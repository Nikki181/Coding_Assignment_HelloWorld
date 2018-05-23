namespace ConsoleApp.Services
{
    using HelloWorldInfrastructure.Models;
    //     Service for communicating with the Hello World Web API
        public interface IHelloWorldWebService
    {
        TodaysData GetTodaysData();
    }
}