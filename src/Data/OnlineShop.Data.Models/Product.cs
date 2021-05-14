namespace OnlineShop.Data.Models
{
    using OnlineShop.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }
    }
}
