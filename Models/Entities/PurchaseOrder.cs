using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class PurchaseOrder: BaseOrder
    {
        public PurchaseOrder()
        {

        }
        public PurchaseOrder(int id, string bpCode, List<PurchaseOrderLine> Lines)
        {
            Id = id;
            BpCode = bpCode;
            this.Lines = Lines;
        }
        public List<PurchaseOrderLine> Lines = new List<PurchaseOrderLine>();
    }
}
