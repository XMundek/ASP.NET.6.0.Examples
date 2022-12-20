using MVCTestApp.Models;

namespace MVCTestApp.Services
{
    public interface IDataProvider<T>
    {
        T[] GetData();
    }
    public interface IProductDataProvider : IDataProvider<Product>
    {

    }
}
