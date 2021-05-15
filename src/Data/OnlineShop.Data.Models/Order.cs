namespace OnlineShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using OnlineShop.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int Quantity { get; set; }

        public bool IsCheckout { get; set; }
    }
}
