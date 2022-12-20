using MVCTestApp.Models;

namespace MVCTestApp.Services
{
    public class ProductDataProvider : IProductDataProvider
    {
        static Product[] data;
        static object lockObject =new object();
        private Product[] LoadData()
        {
            var list = new Product[]
                {
                new Product(){Id = 1, Name="Produkt pierwszy", Price=20},
                new Product(){Id = 2, Name="Produkt drugi", Price=2034},
                };
            return list;
        }
        public Product[] GetData()
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    data = LoadData();
                }
            }
            return data.ToArray();
        }
    }
}
