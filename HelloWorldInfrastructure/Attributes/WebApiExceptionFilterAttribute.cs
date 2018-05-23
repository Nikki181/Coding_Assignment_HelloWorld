namespace HelloWorldInfrastructure.Attributes
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    using HelloWorldInfrastructure.Models;
    using HelloWorldInfrastructure.Resources;
    using HelloWorldInfrastructure.Services;

    public enum SeverityCode
    {

        //     No severity level

        None,
        //     Information severity level

        Information,
        //     Warning severity level

        Warning,
        //     Error severity level

        Error,
        //     Critical severity level

        Critical
    }
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public Type Type { get; set; }

        public HttpStatusCode Status { get; set; }
public SeverityCode Severity { get; set; }
        public ILogger Logger { get; set; }
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;
            if (exception.GetType() == this.Type)
            {
                var innerMessage = context.Exception.InnerException != null
                                       ? context.Exception.InnerException.Message
                                       : context.Exception.Message;


                context.Response = context.Request.CreateResponse(
                    this.Status,
                    new ErrorResponseContent
                    {
                        ErrorCode = context.Exception.Message,
                        Message = innerMessage,
                        ExceptionType = context.Exception.GetType().ToString(),
                        FullException = string.Empty,
                        Severity = this.Severity.ToString()
                    });


                this.Logger.Error(innerMessage, null, context.Exception);
            }
            else
            {
                if ((this.Type == null) && (context.Response == null))
                {
                   
                    context.Response = context.Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                        new ErrorResponseContent
                        {
                            ErrorCode = ErrorCodes.GeneralError,
                            Message = context.Exception.Message,
                            ExceptionType = context.Exception.GetType().ToString(),
                            FullException = string.Empty,
                            Severity = SeverityCode.Critical.ToString()
                        });
                    this.Logger.Error(ErrorCodes.GeneralError, null, context.Exception);
                }
            }
        }
    }
}