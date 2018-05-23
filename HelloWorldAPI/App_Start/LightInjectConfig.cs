

namespace HelloWorldAPI
{
    using System.Web.Http;

    using HelloWorldInfrastructure.FrameworkWrappers;
    using HelloWorldInfrastructure.Mappers;
    using HelloWorldInfrastructure.Services;
    using LightInject;

    public static class LightInjectConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new ServiceContainer();
            container.RegisterApiControllers();

            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);
            container.EnableMvc();

            RegisterServices(container);
        }

        private static void RegisterServices(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IAppSettings, ConfigAppSettings>();
            serviceRegistry.RegisterInstance(typeof(ILogger), new JsonL4NLogger());
            serviceRegistry.Register<IHostingEnvironmentService, ServerHostingEnvironmentService>();
            serviceRegistry.Register<IFileIOService, TextFileIOService>();
            serviceRegistry.Register<IDataService, HelloWorldDataService>();
            serviceRegistry.Register<IDateTime, SystemDateTime>();
            serviceRegistry.Register<IHelloWorldMapper, HelloWorldMapper>();
        }
    }
}
