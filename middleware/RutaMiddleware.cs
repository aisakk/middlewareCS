public class RutaMiddleware
{
    private readonly RequestDelegate _next;

    public RutaMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value.ToLower();

        if (path == "/rutas-especificas")
        {
            await context.Response.WriteAsync("¡Bienvenido!");
        }
        else
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("¡Eres un intruso!");
        }

        await _next(context);
    }
}

