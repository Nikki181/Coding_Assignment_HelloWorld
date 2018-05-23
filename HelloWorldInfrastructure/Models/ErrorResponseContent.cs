namespace HelloWorldInfrastructure.Models
{
    public class ErrorResponseContent
    {

        public string ErrorCode { get; set; }

        public string Message { get; set; }

        public string ExceptionType { get; set; }

        public string FullException { get; set; }


        public string Severity { get; set; }
    }
}
