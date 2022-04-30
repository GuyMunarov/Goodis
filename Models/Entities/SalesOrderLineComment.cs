using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class SalesOrderLineComment
    {
        [Key, Required]
        public int? CommentLineID { get; set; }

        public int? DocId { get; set; }
        [Required]
        public SaleOrder? Doc { get; set; }
        public int? LineId { get; set; }
       [Required]
        public SaleOrderLine? Line { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
