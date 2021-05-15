namespace OnlineShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingCartController : Controller
    {
        public ShoppingCartController()
        {

        }

        public IActionResult Cart()
        {
            return this.View();
        }
    }
}
