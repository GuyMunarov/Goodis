using Models.Entities;
using Models.Specifications.SpecificationsParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Specifications
{
    public class SaleOrderLineCommentsSpecification : BaseSpecification<SalesOrderLineComment>
    {
        public SaleOrderLineCommentsSpecification(int orderId)
            : base(x => x.DocId == orderId)
        {
        }

        public SaleOrderLineCommentsSpecification(CommentSpecParams parameters)
            : base(x => x.LineId == parameters.LineId)
        {
        }
    }
}
