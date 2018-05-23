
namespace HelloWorldInfrastructure.Services
{
    using System.Web.Hosting;
    public class ServerHostingEnvironmentService : IHostingEnvironmentService
    {
       
        public string MapPath(string path)
        {
            return HostingEnvironment.MapPath("~/" + path);
        }
    }
}