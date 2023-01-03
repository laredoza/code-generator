using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CodeGenerator.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public class ErrorController : ControllerBase
    {
        readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("/error")]
        public ActionResult Error([FromServices] IHostEnvironment webHostEnvironment)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;
            var isDev = webHostEnvironment.IsDevelopment();
            _logger.LogError(ex.InnerException ?? ex, "An error occurred.");

            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = isDev ? $"{ex.GetType().Name}: {ex.InnerException?.Message ?? ex.Message}" : "An error occurred.",
                Detail = isDev ? ex.InnerException?.StackTrace ?? ex.StackTrace : null,
            };

            return StatusCode(problemDetails.Status.Value, problemDetails);
        }
    }
}
