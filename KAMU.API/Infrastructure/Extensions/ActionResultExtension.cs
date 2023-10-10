using KAMU.API.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KAMU.API.Infrastructure.Extensions
{
    /// <summary>
    /// Convert action response into mvc action result
    /// </summary>
    public static class ActionResultExtension
    {
        /// <summary>
        /// Convert action response into mvc action result
        /// </summary>
        /// <param name="response">Handles request responses</param>
        /// <returns>MVC Action Result</returns>
        public static IActionResult ResponseResult(this ActionResponse response)
        {
            return response.StatusCode switch
            {
                StatusCodes.Status400BadRequest => new BadRequestObjectResult(response),
                StatusCodes.Status404NotFound => new NotFoundObjectResult(response),
                StatusCodes.Status401Unauthorized => new UnauthorizedObjectResult(response),
                StatusCodes.Status500InternalServerError => new CustomObjectResult(response, StatusCodes.Status500InternalServerError),
                StatusCodes.Status200OK => new OkObjectResult(response),
                _ => new OkObjectResult(response)
            };

        }
    }

    /// <summary>
    /// Creates an object result based on status code
    /// </summary>
    public class CustomObjectResult : ObjectResult
    {
        public CustomObjectResult(object? value, int statusCode) : base(value)
        {
            StatusCode = statusCode;
        }
    }
}
