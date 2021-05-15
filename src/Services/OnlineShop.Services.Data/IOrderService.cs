namespace OnlineShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        Task AddAsync(int productId, string userId);

        Task RemoveAsync(int orderId);

        Task IncrementQuantity(int orderId);

        Task DecrementQuantity(int orderId);

        Task<IEnumerable<T>> GetAllByUserAsync<T>(string userId);
    }
}
