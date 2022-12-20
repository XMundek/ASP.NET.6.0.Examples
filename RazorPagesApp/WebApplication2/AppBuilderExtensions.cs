namespace WebApplication2
{
    public static class AppBuilderExtensions
    {
        public static void UseMyMappings(this IApplicationBuilder app)
        {
            app.Map("/Test", (map) =>
            {
                map.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Run middleware 		inside of map middleware");
                });
            });

            app.Map("/Test2", (map) =>
            {
                app.Use(async (c, next) =>
                {
                    await c.Response.WriteAsync("1<br/>");
                    if (c.Request.Path.ToString().StartsWith(@"/Test2/first"))
                    {
                        await c.Response.WriteAsync("first use");
                    }
                    else
                    {
                        await next.Invoke();
                    }
                });
                map.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Test2");
                });
            });

        }
    }
}
