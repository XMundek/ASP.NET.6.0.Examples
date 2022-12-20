using System.ComponentModel;

namespace MVCTestApp.Models
{
    public class Product
    {
        [DisplayName("Identyfikat")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal PriceTotal => Price * 1.23M;
    }
}
