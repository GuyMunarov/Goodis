using Infrastracture.Data;
using Infrastracture.DataAccess;
using Models.Entities;
using Models.Interfaces;

namespace Repositories
{
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>, IOrderRepository<PurchaseOrder>
    {
        public PurchaseOrderRepository(DataContext context) : base(context)
        {
        }

        public PurchaseOrder Add(PurchaseOrder order)
        {
            throw new NotImplementedException();
        }

        public void Delete(PurchaseOrder order)
        {
            throw new NotImplementedException();
        }

        public PurchaseOrder Get(PurchaseOrder order)
        {
            throw new NotImplementedException();
        }

        public PurchaseOrder Update(PurchaseOrder order)
        {
            throw new NotImplementedException();
        }
    }
}