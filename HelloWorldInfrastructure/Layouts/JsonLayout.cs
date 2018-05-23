
namespace HelloWorldInfrastructure.Layouts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using log4net.Core;
    using log4net.Layout;
    using Newtonsoft.Json;

    public class JsonLayout : LayoutSkeleton
    {
        
        public override void ActivateOptions()
        {
        }
        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var dictionary = new Dictionary<string, object>();

            // Add the main properties
            dictionary.Add("timestamp", loggingEvent.TimeStamp);
            dictionary.Add("level", loggingEvent.Level != null ? loggingEvent.Level.DisplayName : "null");
            dictionary.Add("message", loggingEvent.RenderedMessage);
            dictionary.Add("logger", loggingEvent.LoggerName);

            // Loop through all other properties
            foreach (DictionaryEntry dictionaryEntry in loggingEvent.GetProperties())
            {
                var key = dictionaryEntry.Key.ToString();

                // Check if the key exists
                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, dictionaryEntry.Value);
                }
            }
            
            var logString = JsonConvert.SerializeObject(dictionary);

            writer.WriteLine(logString);
        }
    }
}
