using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace APIApps.CustomOps.CustomMiddlewares
{
    internal class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } = null!;
    }

    public class ExceptionMiddleware
    {
        RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// The method that contains the Logic for Middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // If No Error THen Continue execution with next Middleware in pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Handle the Execption and generate response
                // 1. Set the CUstom Statuc Code
                context.Response.StatusCode = 500;
                // 2. Get the Error Message
                string errorMessage = ex.Message;
                
                // 3. STore this data in the ErrorDetails
                ErrorDetails errorDetails = new ErrorDetails() 
                {
                     StatusCode = context.Response.StatusCode,
                     ErrorMessage = errorMessage
                };
                // 4. Write the Response
                await context.Response.WriteAsJsonAsync(errorDetails);
            }
        }
    }

    // a class to Register the Middleware
    public static class ErrorMiddlewareExtension
    {
        public static void UseAppExceptionHandler(this IApplicationBuilder builder)
        {
            // Register the ExceptionMiddleware as Ustom Middleware
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }

}
