namespace OnlineShop.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Data;

    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> AddOrder(int productId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.orderService.AddAsync(productId, user.Id);

            return this.RedirectToAction("ProductPage", "Products");
        }
    }
}
