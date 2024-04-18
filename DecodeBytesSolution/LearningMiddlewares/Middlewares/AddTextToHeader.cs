namespace LearningMiddlewares.Middlewares
{
    public class AddTextToHeader
    {
        public RequestDelegate _next;
        public AddTextToHeader(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("secret-header", out var value))
            {
                if (value == "secret")
                {
                    await _next(context);
                }
            }
        }
    }

    public static class Extensions
    {
       public static IApplicationBuilder UseHeaderMotification(this IApplicationBuilder app)
        {
           return app.UseMiddleware<AddTextToHeader>();
        }
    }
   
}
