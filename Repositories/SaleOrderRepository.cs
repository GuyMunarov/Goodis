using Infrastracture.Data;
using Infrastracture.DataAccess;
using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SaleOrderRepository : GenericRepository<SaleOrder>, IOrderRepository<SaleOrder>
    {
        public SaleOrderRepository(DataContext context) : base(context)
        {
        }

        public SaleOrder Add(SaleOrder order)
        {
            throw new NotImplementedException();
        }

        public void Delete(SaleOrder order)
        {
            throw new NotImplementedException();
        }

        public SaleOrder Get(SaleOrder order)
        {
            throw new NotImplementedException();
        }

        public SaleOrder Update(SaleOrder order)
        {
            throw new NotImplementedException();
        }
    }
}