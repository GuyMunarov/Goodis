using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class SaleOrder : BaseOrder
    {
        public SaleOrder()
        {

        }
        public SaleOrder(int id,string bpCode, List<SaleOrderLine> Lines)
        {
            Id = id;
            BpCode = bpCode;
            this.Lines = Lines;
        }
        public List<SaleOrderLine> Lines = new List<SaleOrderLine>();
    }
}
