namespace HelloWorldInfrastructure.Mappers
{
    using HelloWorldInfrastructure.Models;
        public class HelloWorldMapper : IHelloWorldMapper
    {
        public TodaysData StringToTodaysData(string input)
        {
            return new TodaysData { Data = input };
        }
    }
}