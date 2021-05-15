namespace OnlineShop.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Data;
    using OnlineShop.Web.ViewModels.ShoppingCart;

    public class ShoppingCartController : Controller
    {
        private readonly IOrderService orderService;
        private readonly UserManager<ApplicationUser> userManager;

        public ShoppingCartController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Cart()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var orders = await this.orderService.GetAllByUserAsync<OrderViewModel>(user.Id);

            return this.View(orders);
        }
    }
}
