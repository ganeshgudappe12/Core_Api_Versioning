namespace Core_Api_Versioning
{
    public class ApiVersionHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiVersionHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //if (!context.Request.Headers.ContainsKey("x-api-version")) slower than TryGetValue
            if (!context.Request.Headers.TryGetValue("x-api-version", out var apiVersion))

            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest; // Bad Request
                var errorResponse = new
                {
                    error = new
                    {
                        code = "Status400BadRequest",
                        message = "x-api-version header is required."
                    }
                };

                var json = System.Text.Json.JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(json);
                //await context.Response.WriteAsync("x-api-version header is required.");
                return;
            }

            await _next(context);
        }
    }

}
