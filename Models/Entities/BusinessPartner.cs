using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class BusinessPartner
    {
        [Key, MaxLength(128),Required]
       
        public string BpCode { get; set; }
        [Required]
        public string BPName { get; set; }
        [Required]
        public BpType BpType { get; set; }
        [Required]
        public bool Active { get; set; } = true;

    }
}
