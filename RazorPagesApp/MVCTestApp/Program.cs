using MVCTestApp;
using MVCTestApp.Services;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(options =>
{
   // options.AddPolicy("AdminPolicy", policy =>
   //     policy.Requirements.Add(new AdminPolicy()));
});


var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Logging.AddSerilog(logger);
builder.RegisterServices();

//builder.Services.AddTransient<IProductDataProvider,ProductDataProvider>();
//builder.Services.AddSingleton<Func<IProductDataProvider>>(()=>new ProductDataProvider());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMyAuthentication();
//app.UseMyAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
