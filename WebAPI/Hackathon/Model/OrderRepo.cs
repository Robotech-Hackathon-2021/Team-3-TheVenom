using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Model
{
    public class OrderRepo : IOrder
    {
        private readonly AppDbContext appDbContext;
        public OrderRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Order> AddOrder(Order order)
        {
            var result = await appDbContext.Orders.AddAsync(order);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Order> DeleteOrder(int orderId)
        {
            var result = await appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (result != null)
            {
                appDbContext.Orders.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await appDbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrder(int orderId)
        {
            return await appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var result = await appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (result != null)
            {
                result.Name = order.Name;
                result.Items = order.Items;
                result.Total = order.Total;
                result.PhoneNumber = order.PhoneNumber;
               

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
