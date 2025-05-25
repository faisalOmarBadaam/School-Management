using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Helpers.BaseResponse;
using SchoolProject.Data.Exceptions;

namespace SchoolProjectApi.GlobalExcepion
{
    public class GlobalException(ILogger<GlobalException> logger, IProblemDetailsService problemService) : IExceptionHandler
    {
        private readonly IProblemDetailsService problemService = problemService;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails
            {
                Instance = httpContext.Request.Path
            };

            logger.LogError("{ProblemDetailsTitle}", problemDetails.Title);
            httpContext.Response.StatusCode = exception switch
            {
                BadInputException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                ValidationAppException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
            httpContext.Response.ContentType = "application/json";

            if (exception is ValidationAppException validationException)
            {
                var response = new BaseResponse<ValidationAppException>(false, null, validationException.Message, validationException.Errors.ToDictionary());
                await httpContext.Response.WriteAsJsonAsync(response);
                return true;
            }
            else if (exception is NotFoundException notFoundException)
            {
                var response = new BaseResponse<NotFoundException>(false, null, notFoundException.Message);
                await httpContext.Response.WriteAsJsonAsync(response);
                return true;
            }
            return await problemService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails =
                {
                    Title = "an error ouccred",
                    Detail = exception.Message,
                    Type = exception.GetType().Name,
                    Status = httpContext.Response.StatusCode,

                }


            });
        }
    }
}
