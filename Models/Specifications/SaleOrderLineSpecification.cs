using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Specifications
{
    public class SaleOrderLineSpecification : BaseSpecification<SaleOrderLine>
    {
        public SaleOrderLineSpecification(int orderId)
            : base(x => x.DocID == orderId)
        {
            AddInclude(x => x.CreatedBy);
            AddInclude(x => x.Item);
        }
    }
}
