using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class BpType
    {

        [Key,MaxLength(1),Required]
        public string TypeCode { get; set; }
        [MaxLength(20),Required]
        public string TypeName { get; set; }
        public List<BusinessPartner> BusinessPartners { get; set; }
    }
}
