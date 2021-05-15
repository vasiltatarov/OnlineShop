namespace OnlineShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        Task AddAsync(int productId, string userId);

        Task RemoveAsync();

        Task IncrementQuantity();

        Task DecrementQuantity();

        IEnumerable<T> GetAllByUser<T>(string userId);
    }
}
