namespace OnlineShop.Services.Data
{
    using System.Threading.Tasks;

    public interface IProductsService
    {
        Task Create(string title, string description, string imagePath, decimal price);
    }
}
