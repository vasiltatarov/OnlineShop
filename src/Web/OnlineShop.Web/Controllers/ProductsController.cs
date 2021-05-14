namespace OnlineShop.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
        public IActionResult GetProducts()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        //[HttpPost]
        //public IActionResult Create()
        //{
        //    return this.View();
        //}
    }
}
