namespace OnlineShop.Web.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class ProductInputViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Range(typeof(decimal), "1", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
