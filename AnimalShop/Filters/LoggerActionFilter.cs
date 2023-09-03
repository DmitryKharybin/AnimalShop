using Microsoft.AspNetCore.Mvc.Filters;

namespace AnimalShop.Filters
{
    public class LoggerActionFilter : ActionFilterAttribute
    {

        private ILogger<LoggerActionFilter> _logger;

        public LoggerActionFilter(ILogger<LoggerActionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? actionName = context.ActionDescriptor.RouteValues["action"];

            _logger.LogInformation($"{actionName} has started");
            _logger.LogInformation("EXECUTING");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string? actionName = context.ActionDescriptor.RouteValues["action"];

            _logger.LogInformation($"{actionName} has ended");
            _logger.LogInformation("EXECUTED");
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            string? actionName = context.ActionDescriptor.RouteValues["action"];

            _logger.LogInformation($"{actionName} has started");
            _logger.LogInformation("EXECUTING");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            string? actionName = context.ActionDescriptor.RouteValues["action"];

            _logger.LogInformation($"{actionName} has started");
            _logger.LogInformation("EXECUTED");
        }
    }
}
