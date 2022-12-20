using WebApplication2;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseMyMappings();



//app.Use(async (c, next) => {
//    c.Response.ContentType = @"text/html";         
//    await next.Invoke();    
//});

//app.Use(async (c, next) => {
//    await c.Response.WriteAsync("1<br/>");
//    if (c.Request.Path.ToString().StartsWith(@"/first"))
//    {
//        await c.Response.WriteAsync("first use");
//    }
//    else
//    {
//        await next.Invoke();
//    }
//});
//app.Use(async (c, next) => {
//    await c.Response.WriteAsync("2<br/>");
//    if (c.Request.Path.ToString().StartsWith(@"/second"))
//    {
//        await c.Response.WriteAsync("second use");
//    }
//    else
//    {
//        await next.Invoke();
//    }
//});
//app.Run(async c => await c.Response.WriteAsync("Invalid path"));
//app.Run(async c => await c.Response.WriteAsync("Hello"));
app.Run();
