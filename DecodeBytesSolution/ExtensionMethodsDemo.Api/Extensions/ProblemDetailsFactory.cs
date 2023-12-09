using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ExtensionMethodsDemo.Api.Extensions
{
    public static class ProblemDetailsExtensions
    {
        public static ProblemDetails CreateNotFoundDetails(
            this ProblemDetailsFactory detailsFactory,
            HttpContext context,
            string? message = null)
        {
            return detailsFactory.CreateProblemDetails(context, statusCode: StatusCodes.Status404NotFound, detail: message);
        }

        public static ProblemDetails CreateBadRequestDetails(
            this ProblemDetailsFactory detailsFactory,
            HttpContext context,
            string? details = null)
        {
            return detailsFactory.CreateProblemDetails(context, statusCode: StatusCodes.Status400BadRequest, detail: details);
        }
    }
}
