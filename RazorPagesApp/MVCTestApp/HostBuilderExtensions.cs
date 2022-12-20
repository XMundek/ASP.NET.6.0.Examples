using MVCTestApp.Services;

namespace MVCTestApp
{
    public static class HostBuilderExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IProductDataProvider, ProductDataProvider>();
        }
    }
}
