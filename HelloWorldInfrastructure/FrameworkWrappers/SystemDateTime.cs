

namespace HelloWorldInfrastructure.FrameworkWrappers
{
    using System;

    public class SystemDateTime : IDateTime
    {

        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}