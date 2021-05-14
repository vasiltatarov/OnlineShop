namespace OnlineShop.Web.ViewModels.Products
{
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Mapping;

    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }
    }
}
