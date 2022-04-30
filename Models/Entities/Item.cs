using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Item
    {
        [Key,Required,MaxLength(128)]
        public string ItemCode { get; set; }
        [Required,MaxLength(254)]
        public string ItemName { get; set; }
        [Required]
        public bool Active { get; set; } = true;
    }
}
