using OnlineShop.Services.Data;

namespace OnlineShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingCartController : Controller
    {
        private readonly IOrderService orderService;

        public ShoppingCartController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Cart()
        {
            // Add OrderViewModel and pass to view
            return this.View();
        }
    }
}
