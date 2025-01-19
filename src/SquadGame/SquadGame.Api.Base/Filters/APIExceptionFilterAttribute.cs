using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using SquadGame.Api.Base.Exceptions;
using SquadGame.Api.Base.Responses;
using static SquadGame.Api.Base.Constants.Constants;
using ILogger = Serilog.ILogger;

namespace SquadGame.Api.Base.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class APIExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public ILogger Logger { get; set; }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ExceptionBase exception)
            {
                Logger?.Warning(exception, "Handled exception");
                context.HttpContext.Response.StatusCode = exception.StatusCode;
                context.Result = new ErrorResult(exception);
            }
            else
            {
                Logger?.Error(context.Exception, "Unhandled exception");
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ErrorResult(ExceptionCodes.UnhandledError,
                    context.Exception.Message, context.Exception.InnerException);
            }
        }
    }
}
