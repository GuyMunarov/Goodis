using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Specifications
{
    public class PurchaseOrderLinesSpecification : BaseSpecification<PurchaseOrderLine>
    {
        public PurchaseOrderLinesSpecification(int docId)
            : base(x =>
           x.DocID == docId)
        {
            AddInclude(x => x.CreatedBy);
            AddInclude(x => x.Item);
        }
    }
}
