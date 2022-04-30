using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Specifications
{
    public class PurchaseOrderSpecification : BaseSpecification<PurchaseOrder>
    {
        public PurchaseOrderSpecification(int id)
            : base(x =>
           x.Id == id)
        {
            AddInclude(x => x.BusinessPartner);
            AddInclude(x => x.LastUpdatedBy);
            AddInclude(x => x.CreatedBy);
        }
    }
}
