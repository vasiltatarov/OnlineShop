namespace OnlineShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductsService
    {
        Task Create(string title, string description, string imagePath, decimal price);

        Task<IEnumerable<T>> GetAll<T>();
    }
}
