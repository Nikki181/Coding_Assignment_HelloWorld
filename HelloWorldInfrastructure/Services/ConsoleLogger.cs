
namespace HelloWorldInfrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using HelloWorldInfrastructure.FrameworkWrappers;

    public class ConsoleLogger : ILogger
    {
        //     The Console abstraction for writing to the console.

        private readonly IConsole console;


        public ConsoleLogger(IConsole console)
        {
            this.console = console;
        }
        public void Info(string message, Dictionary<string, object> otherProperties)
        {
            this.WriteLog("INFO", message, otherProperties, null);
        }
        public void Debug(string message, Dictionary<string, object> otherProperties)
        {
            this.WriteLog("DEBUG", message, otherProperties, null);
        }
        public void Error(string message, Dictionary<string, object> otherProperties, Exception exception)
        {
            this.WriteLog("ERROR", message, otherProperties, exception);
        }
        private void WriteLog(string logLevel, string message, Dictionary<string, object> otherProperties, Exception exception)
        {

            var builder = new StringBuilder(logLevel);
            builder.Append(": ");
            builder.Append(message);


            if (otherProperties != null)
            {
                foreach (var property in otherProperties)
                {
                    if (property.Key != null && property.Value != null)
                    {
                        builder.Append(" [");
                        builder.Append(property.Key);
                        builder.Append("=");
                        builder.Append(property.Value);
                        builder.Append("]");
                    }
                }
            }
            
            if (exception != null)
            {
                builder.Append(" [Exception: ");
                builder.Append(exception);
                builder.Append("]");
            }
            
            this.console.WriteLine(builder.ToString());
        }
    }
}