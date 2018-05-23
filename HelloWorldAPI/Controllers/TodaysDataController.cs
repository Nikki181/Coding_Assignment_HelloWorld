namespace HelloWorldAPI.Controllers
{
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Web.Http;
    using HelloWorldInfrastructure.Attributes;
    using HelloWorldInfrastructure.Models;
    using HelloWorldInfrastructure.Services;
        [WebApiExceptionFilter]
    public class TodaysDataController : ApiController
    {
        private readonly IDataService dataService;
        public TodaysDataController(IDataService dataService)
        {
            this.dataService = dataService;
        }
        [WebApiExceptionFilter(Type = typeof(IOException), Status = HttpStatusCode.ServiceUnavailable, Severity = SeverityCode.Error)]
        [WebApiExceptionFilter(Type = typeof(SettingsPropertyNotFoundException), Status = HttpStatusCode.ServiceUnavailable, Severity = SeverityCode.Error)]
        public TodaysData Get()
        {
            return this.dataService.GetTodaysData();
        }
    }
}