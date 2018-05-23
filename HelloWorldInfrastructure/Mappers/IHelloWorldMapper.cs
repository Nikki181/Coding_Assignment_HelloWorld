
namespace HelloWorldInfrastructure.Mappers
{
    using HelloWorldInfrastructure.Models;
    
    public interface IHelloWorldMapper
    {
        TodaysData StringToTodaysData(string input);
    }
}