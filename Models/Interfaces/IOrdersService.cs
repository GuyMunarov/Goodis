using Models.Entities;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IOrdersService
    {
        public Task<IOrder> CreateOrder(IOrder order);
        public Task<IOrder> UpdateOrder(IOrder order);

        public Task<IOrder> GetOrder(OrderType type, int id);
        public Task DeleteOrder(OrderType type, int id);

    }
}
