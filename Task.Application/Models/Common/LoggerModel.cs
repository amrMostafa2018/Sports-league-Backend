using System;

namespace Task.Application.Dtos.Common
{
    public class LoggerModel
    {
        public Exception ExceptionError { get; set; }
        public string ErrorMessage { get; set; }
        public object UserRequestModel { get; set; }
        public string EndPoint { get; set; }
    }
}