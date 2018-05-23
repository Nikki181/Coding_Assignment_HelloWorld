
namespace HelloWorldInfrastructure.FrameworkWrappers
{
    using System;
    
    public class SystemUri : IUri
    {
    
        public Uri GetUri(string uriString)
        {
            return new Uri(uriString);
        }
    }
}