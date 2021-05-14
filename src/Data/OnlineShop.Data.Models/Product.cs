namespace OnlineShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using OnlineShop.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Range(typeof(decimal), "1", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
