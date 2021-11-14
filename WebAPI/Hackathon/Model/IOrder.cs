using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Model
{
    public interface IOrder
    {
        //All Details
        Task<IEnumerable<Order>> GetOrder();
        //Single Details
        Task<Order> GetOrder(int orderId);
        //Add an Order
        Task<Order> AddOrder(Order order);
        //Update an Order
        Task<Order> UpdateOrder(Order order);
        //Delete an Order
        Task<Order> DeleteOrder(int orderId);
    }
}
