var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseMiddleware<RutaMiddleware>();
app.Use(async (context, next)=>{
    var path = context.Request.Path.Value.ToLower();
   
        if (path == "/rutas")
        {
            await context.Response.WriteAsync("¡Bienvenido!");
        }
        else
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("¡Eres un intruso!");
        }
        Console.WriteLine(path);
        await next(context);
});
app.MapGet("/", () => "Hello World!");

app.Run();
