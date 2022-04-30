using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class BaseOrderLine: InstanceEntity
    {
        [Key]
        public int LineID { get; set; }

        [Required]
        [ForeignKey("Document")]
        public int DocID { get; set; }

        

        [Required]
        [ForeignKey("Item")]
        public string ItemCode { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]
        public decimal Quantity { get; set; }


    }
}
