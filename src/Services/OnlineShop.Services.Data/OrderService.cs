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
            var order = await this.orderRepository.AllWithDeleted()
                .FirstOrDefaultAsync(x => x.ProductId == productId && x.UserId == userId);

            if (order != null)
            {
                if (order.IsDeleted)
                {
                    order.IsDeleted = false;
                    order.Quantity = 1;
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

        public async Task RemoveAsync(int orderId)
        {
            var order = await this.orderRepository.All()
                .FirstOrDefaultAsync(x => x.Id == orderId);
            order.IsDeleted = true;
            await this.orderRepository.SaveChangesAsync();
        }

        public async Task IncrementQuantity(int orderId)
        {
            var order = await this.orderRepository.All()
                .FirstOrDefaultAsync(x => x.Id == orderId);
            order.Quantity++;
            await this.orderRepository.SaveChangesAsync();
        }

        public async Task DecrementQuantity(int orderId)
        {
            var order = await this.orderRepository.All()
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order.Quantity <= 1)
            {
                return;
            }

            order.Quantity--;
            await this.orderRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllByUserAsync<T>(string userId)
            => await this.orderRepository.All()
                .Where(x => x.UserId == userId)
                .To<T>()
                .ToListAsync();
    }
}
