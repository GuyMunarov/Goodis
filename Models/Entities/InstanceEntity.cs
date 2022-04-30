using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class InstanceEntity
    {
        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }
        [Required]
        public AppUser CreatedBy { get; set; }
        public AppUser? LastUpdatedBy { get; set; }
        public int? LastUpdatedById { get; set; }

        public int CreatedById { get; set; }

    }
}
