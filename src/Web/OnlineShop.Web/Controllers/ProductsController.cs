namespace OnlineShop.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineShop.Services.Data;
    using OnlineShop.Web.ViewModels.Products;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly IUnitOfWork unitOfWork;

        public ProductsController(IProductsService productsService, IUnitOfWork unitOfWork)
        {
            this.productsService = productsService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ProductPage() // Get all products and make ProductViewModel for any of the products
        {
            var products = await this.productsService.GetAll<ProductViewModel>();
            return this.View(products);
        }

        [Authorize]
        public IActionResult Create()
        {
            var inputModel = new ProductInputViewModel();
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("ProductPage");
            }

            await this.unitOfWork.UploadImage(input.Image);

            await this.productsService.Create(input.Title, input.Description, input.Image.FileName, input.Price);

            return this.RedirectToAction("ProductPage");
        }
    }
}
