using MVCTestApp.Controllers;
using Moq;
using MVCTestApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using MVCTestApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void Index_ReturnsProperModel_AndView()
        {
            //init

            var data = new Product[]
            {
                new Product(){Id=1, Name="sadasd"}

            };
            //var t = new Mock<IProductDataProvider>();
            //t.Setup(p => p.GetData()).Returns(data);
            //var d = t.Object;

            var dataProvider = Mock.Of<IProductDataProvider>(x=>x.GetData()==data);
            var section = Mock.Of<IConfigurationSection>(p => p["ProductView"] == "Test");
            var config = Mock.Of<IConfiguration>(p=>p.GetSection("AppSettings")==section);

            var productController = new ProductController(dataProvider, config);
            //run
            var result = productController.Index() as ViewResult;


            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(data, result.Model);
            Assert.AreEqual("Test", result.ViewName);
            
            //Mock.Get(dataProvider).Verify()
            //t.Verify(p=>p.GetData(),Times.Once());

        }
    }
}