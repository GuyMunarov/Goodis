using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class SaleOrderLine: BaseOrderLine
    {
        [Required]
        public SaleOrder Document { get; set; }

        public List<SalesOrderLineComment> Comments = new List<SalesOrderLineComment>();
    }
}
