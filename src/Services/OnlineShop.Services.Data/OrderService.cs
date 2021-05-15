namespace OnlineShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using OnlineShop.Data.Common.Repositories;
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Mapping;

    public class OrderService : IOrderService
    {
        private readonly IDeletableEntityRepository<Order> orderRepository;

        public OrderService(IDeletableEntityRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task AddAsync(int productId, string userId)
        {
            var order = await this.orderRepository.All()
                .FirstOrDefaultAsync(x => x.ProductId == productId && x.UserId == userId);

            if (order != null)
            {
                if (order.IsDeleted)
                {
                    order.IsDeleted = false;
                }
                else
                {
                    return;
                }
            }
            else
            {
                order = new Order
                {
                    ProductId = productId,
                    UserId = userId,
                    Quantity = 1,
                };
                await this.orderRepository.AddAsync(order);
            }

            await this.orderRepository.SaveChangesAsync();
        }

        public Task RemoveAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task IncrementQuantity()
        {
            throw new System.NotImplementedException();
        }

        public Task DecrementQuantity()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllByUserAsync<T>(string userId)
            => await this.orderRepository.All()
                .Where(x => x.UserId == userId)
                .To<T>()
                .ToListAsync();
    }
}
