using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Specifications
{
    public class SaleOrderSpecification : BaseSpecification<SaleOrder>
    {
        public SaleOrderSpecification(int id)
            : base(x =>
           x.Id == id)
        {
            AddInclude(x => x.BusinessPartner);
            AddInclude(x => x.LastUpdatedBy);
            AddInclude(x => x.CreatedBy);
        }
    }
}