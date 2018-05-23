

namespace HelloWorldInfrastructure.Services
{
    using HelloWorldInfrastructure.Models;

    public interface IDataService
    {
        TodaysData GetTodaysData();
    }
}