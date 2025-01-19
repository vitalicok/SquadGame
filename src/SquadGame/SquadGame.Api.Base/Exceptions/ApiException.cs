using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SquadGame.Api.Base.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; }

        protected ApiException()
        {
        }

        public ApiException(string message,
            int statusCode = 500) :
            base(message)
        {
            StatusCode = statusCode;
            ContentType = "application/json";
        }

        public ApiException(string message, int statusCode, params object[] messageArgs)
            : base(string.Format(message, messageArgs))
        {
            StatusCode = statusCode;
            ContentType = "application/json";
        }
    }
}
