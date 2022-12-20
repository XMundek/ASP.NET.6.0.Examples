using Microsoft.AspNetCore.Mvc;
using MVCTestApp.Models;
using MVCTestApp.Services;

namespace MVCTestApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductDataProvider dataProvider;
        private Func<IProductDataProvider> dataProviderFactory;
        private IConfiguration config;

        //public ProductController(Func<IProductDataProvider> dataProvider, IConfiguration config)
        //{
        //    this.dataProviderFactory = dataProvider;
        //    this.config = config;
        //}

        public ProductController(IProductDataProvider dataProvider, IConfiguration config)
        {
            this.dataProvider = dataProvider;
            this.config = config;
        }
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Index()
        {
            //var data = this.dataProviderFactory().GetData();
            var data = this.dataProvider.GetData();
            //var service = this.HttpContext.RequestServices.GetService<IProductDataProvider>();
            //var data = service.GetData();
            var viewName = config.GetSection("AppSettings")["ProductView"];
            //ViewBag.myData = list;
            if (string.IsNullOrEmpty(viewName))
            {
                return View(data);
            }
            else
            {
                return View(viewName, data);
            }
        }
    }
}
